using System;

namespace Dolittle.Applications
{
    /// <summary>
    /// The exception that gets thrown when a <see cref="IApplicationStructure"/> is validated and it has configured
    /// a <see cref="IApplicationStructureFragment"/> to be recursive when it cannot be.
    /// </summary>
    public class ApplicationStructureFragmentCannotBeRecursive : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationStructureFragmentMustBeRequired"/>
        /// </summary>
        public ApplicationStructureFragmentCannotBeRecursive(IApplicationStructureFragment fragment) 
            : base($"Since the type of the {typeof(IApplicationStructureFragment).AssemblyQualifiedName} is {fragment.Type.AssemblyQualifiedName} "+
            $"it cannot be recursive.") 
            {}
    }
}