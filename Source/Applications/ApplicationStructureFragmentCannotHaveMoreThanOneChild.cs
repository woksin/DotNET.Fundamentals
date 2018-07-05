using System;

namespace Dolittle.Applications
{
    /// <summary>
    /// The exception that gets thrown when a <see cref="IApplicationStructure"/> is validated and it has configured
    /// a <see cref="IApplicationStructureFragment"/> that has more than one child. 
    /// </summary>
    public class ApplicationStructureFragmentCannotHaveMoreThanOneChild : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationStructureFragmentMustBeRequired"/>
        /// </summary>
        public ApplicationStructureFragmentCannotHaveMoreThanOneChild() 
            : base($"An {typeof(IApplicationStructureFragment).AssemblyQualifiedName} cannot be configured to have more that one child {typeof(IApplicationStructureFragment).AssemblyQualifiedName}") 
            {}
    }
}