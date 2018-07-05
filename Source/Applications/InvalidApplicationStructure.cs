using System;
namespace Dolittle.Applications
{
    /// <summary>
    /// The exception that gets thrown when attempting to build an <see cref="Application"/> with an invalid <see cref="ApplicationStructure"/>
    /// </summary>
    public class InvalidApplicationStructure : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of <see cref="InvalidApplicationStructure"/>
        /// </summary>
        public InvalidApplicationStructure(ApplicationName applicationName, IApplicationStructure structure)
            : base($"The {typeof(Application).AssemblyQualifiedName}: {applicationName} was attempted to be built with an invalid " +
            $"{typeof(IApplicationStructure).AssemblyQualifiedName}: {structure}")
            {}
        /// <summary>
        /// Initializes a new instance of <see cref="InvalidApplicationStructure"/> with an inner exception
        /// </summary>
        public InvalidApplicationStructure(ApplicationName applicationName, IApplicationStructure structure, Exception innerException)
            : base($"The {typeof(Application).AssemblyQualifiedName}: {applicationName} was attempted to be built with an invalid " +
            $"{typeof(IApplicationStructure).AssemblyQualifiedName}: {structure}", innerException)
            {}
        
    }
}