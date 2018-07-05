/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using Dolittle.Reflection;

namespace Dolittle.Applications
{
    /// <summary>
    /// Represents an implementation of <see cref="IApplicationStructure"/>
    /// </summary>
    public class ApplicationStructure : IApplicationStructure
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationStructure"/>
        /// </summary>
        /// <param name="root"><see cref="IApplicationStructureFragment">Root fragment</see> for the structure</param>
        public ApplicationStructure(IApplicationStructureFragment root)
        {
            Root = root;
        }

        /// <inheritdoc/>
        public IApplicationStructureFragment Root { get; }

        /// <inheritdoc/>
        public (bool, Exception) IsValid()
        {
            return IsValid(Root);
        }

        (bool, Exception) IsValid(IApplicationStructureFragment root)
        {
            if (root.Children != null && root.Children.Count() > 1) 
                return (false, new ApplicationStructureFragmentCannotHaveMoreThanOneChild());
            if (IApplicationStructureFragmentTypeIsARequiredType(root.Type) && !root.Required) 
                return (false, new ApplicationStructureFragmentMustBeRequired(root));
            if (!IApplicationStructureFragmentTypeCanBeRecursive(root.Type) && !root.Recursive) 
                return (false, new ApplicationStructureFragmentCannotBeRecursive(root));

            if (root.Children != null && Root.Children.Any())
            {
                return IsValid(root.Children.First());
            }
            return (true, null);
        }

        bool IApplicationStructureFragmentTypeIsARequiredType(Type type)
        {
            return type.HasInterface<IAmARequiredStructureFragmentType>();
        }
        bool IApplicationStructureFragmentTypeCanBeRecursive(Type type) 
        {
            return type.HasInterface<IAmARecursiveStructureFragmentType>();
        }
    }
}