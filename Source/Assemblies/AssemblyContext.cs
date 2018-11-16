/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.DependencyModel.Resolution;

namespace Dolittle.Assemblies
{
    /// <summary>
    /// Represents an implementation of <see cref="IAssemblyContext"/>
    /// </summary>
    public class AssemblyContext : IAssemblyContext
    {
        readonly ICompilationAssemblyResolver _assemblyResolver;

        /// <summary>
        /// Initializes a new instance of <see cref="AssemblyContext"/>
        /// </summary>
        /// <param name="assembly">Assembly the context is for</param>
        public AssemblyContext(Assembly assembly)
        {
            Assembly = assembly;

            AssemblyLoadContext = AssemblyLoadContext.GetLoadContext(assembly);
            AssemblyLoadContext.Resolving += OnResolving;

            DependencyContext = DependencyContext.Load(assembly);

            var basePath = Path.GetDirectoryName(assembly.CodeBase);

            _assemblyResolver = new CompositeCompilationAssemblyResolver(new ICompilationAssemblyResolver[]
            {
                new AppBaseCompilationAssemblyResolver(basePath),
                    new ReferenceAssemblyPathResolver(),
                    new PackageCompilationAssemblyResolver(),
                    new PackageRuntimeStoreAssemblyResolver()
            });
        }

        /// <summary>
        /// Create an <see cref="IAssemblyContext"/> from a given <see cref="Assembly"/>
        /// </summary>
        /// <param name="assembly"><see cref="Assembly"/> to use</param>
        /// <returns><see cref="IAssemblyContext"/> for the <see cref="Assembly"/></returns>
        public static IAssemblyContext From(Assembly assembly)
        {
            var context = new AssemblyContext(assembly);
            return context;
        }

        /// <summary>
        /// Create an <see cref="IAssemblyContext"/> from a given path to an <see cref="Assembly"/>
        /// </summary>
        /// <param name="path">Path to the <see cref="Assembly"/> to use</param>
        /// <returns><see cref="IAssemblyContext"/> for the path to the <see cref="Assembly"/></returns>
        public static IAssemblyContext From(string path)
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
            return From(assembly);
        }

        /// <inheritdoc/>
        public Assembly Assembly { get; }

        /// <inheritdoc/>
        public DependencyContext DependencyContext {  get; }

        /// <inheritdoc/>
        public AssemblyLoadContext AssemblyLoadContext {  get; }

        /// <inheritdoc/>
        public IEnumerable<Assembly> GetProjectReferencedAssemblies()
        {
            var libraries = GetLibraries().Where(_ => _.Type.ToLowerInvariant() == "project");
            return LoadAssembliesFrom(libraries);
        }

        /// <inheritdoc/>
        public IEnumerable<Assembly> GetReferencedAssemblies()
        {
            var libraries = GetLibraries();
            return LoadAssembliesFrom(libraries);
        }


        /// <inheritdoc/>
        public void Dispose()
        {
            AssemblyLoadContext.Resolving -= OnResolving;
        }

        Assembly OnResolving(AssemblyLoadContext context, AssemblyName name)
        {
            bool NamesMatch(Library runtime)
            {
                return string.Equals(runtime.Name, name.Name, StringComparison.OrdinalIgnoreCase);
            }

            var library = DependencyContext.RuntimeLibraries.FirstOrDefault(NamesMatch);
            if (library != null)
            {
                var compileLibrary = new CompilationLibrary(
                    library.Type,
                    library.Name,
                    library.Version,
                    library.Hash,
                    library.RuntimeAssemblyGroups.SelectMany(g => g.AssetPaths),
                    library.Dependencies,
                    library.Serviceable,
                    library.Path,
                    library.HashPath);

                var assemblies = new List<string>();
                _assemblyResolver.TryResolveAssemblyPaths(compileLibrary, assemblies);
                if (assemblies.Count > 0)
                {
                    try
                    {
                        return AssemblyLoadContext.LoadFromAssemblyPath(assemblies[0]);
                    } 
                    catch
                    {
                        return null;
                    }
                }
            }

            return null;
        }

        IEnumerable<RuntimeLibrary> GetLibraries()
        {
            var libraries = DependencyContext.RuntimeLibraries.Cast<RuntimeLibrary>()
                .Where(_ => _.RuntimeAssemblyGroups.Count() > 0 && !_.Name.StartsWith("runtime"));
            return libraries;
        }

        IEnumerable<Assembly> LoadAssembliesFrom(IEnumerable<RuntimeLibrary> libraries)
        {
            return libraries
                .Select(_ => {
                    try 
                    {
                        return Assembly.Load(_.Name);
                    } catch 
                    {
                        return null;
                    }
                })
                .Where(_ => _ != null)
                .ToArray();
        }
    }
}