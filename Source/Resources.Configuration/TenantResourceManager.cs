using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dolittle.Lifecycle;
using Dolittle.Logging;
using Dolittle.Serialization.Json;
using Dolittle.Tenancy;
using Dolittle.Types;
using Newtonsoft.Json;

namespace Dolittle.Resources.Configuration
{
    /// <inheritdoc/>
    [Singleton]
    public class TenantResourceManager : ITenantResourceManager
    {
        static readonly string _path = Path.Combine(".dolittle", "resources.json");

        IInstancesOf<ICanDefineAResource> _resourceDefinitions;
        ISerializer _serializer;
        ILogger _logger;
        
        IDictionary<TenantId, ResourceConfiguration> _resourceConfigurationsByTenant;
        

        /// <summary>
        /// Instantiates an instance of <see cref="TenantResourceManager"/>
        /// </summary>
        /// <param name="resourceDefinitions"></param>
        /// <param name="serializer"></param>
        /// <param name="logger"></param>
        public TenantResourceManager(IInstancesOf<ICanDefineAResource> resourceDefinitions, ISerializer serializer, ILogger logger)
        {
            _resourceDefinitions = resourceDefinitions;
            _serializer = serializer;
            _logger = logger;

            var resourceFileContent = ReadResourceFile();

            _resourceConfigurationsByTenant = _serializer.FromJson<Dictionary<TenantId, ResourceConfiguration>>(resourceFileContent);
        }
        
        /// <inheritdoc/>
        public T GetConfigurationFor<T>(TenantId tenantId) where T : class
        {
            var resourceType = RetrieveResourceType<T>();
            var configurationObjectAsString = _resourceConfigurationsByTenant[tenantId].Resources[resourceType].ToString();
            var configurationObject = _serializer.FromJson<T>(configurationObjectAsString); 

            return (T)configurationObject;
        }

        ResourceType RetrieveResourceType<T>()
        {
            var resourceTypesMatchingType = _resourceDefinitions.Where(_ => _.ConfigurationObjectType.Equals(typeof(T)));
            if (!resourceTypesMatchingType.Any()) throw new NoResourceTypeMatchingConfigurationType(typeof(T));
            if (resourceTypesMatchingType.Count() > 1) throw new ConfigurationTypeMappedToMultipleResourceTypes(typeof(T));

            return resourceTypesMatchingType.First().ResourceType;
        }

        string ReadResourceFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), _path);
            if (! File.Exists(path)) throw new MissingResourcesFile();
            return File.ReadAllText(path);
        }
    }
}