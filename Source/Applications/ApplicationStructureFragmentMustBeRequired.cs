using System;

namespace Dolittle.Applications
{
    /// <summary>
    /// The exception that gets thrown when a <see cref="IApplicationStructure"/> is validated and it has configured
    /// a <see cref="IApplicationStructureFragment"/> to be optional when it is required.
    /// </summary>
    public class ApplicationStructureFragmentMustBeRequired : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationStructureFragmentMustBeRequired"/>
        /// </summary>
        /// <param name="fragment"></param>
        public ApplicationStructureFragmentMustBeRequired(IApplicationStructureFragment fragment) 
            : base($"Since the type of the {typeof(IApplicationStructureFragment).AssemblyQualifiedName} is {fragment.Type.AssemblyQualifiedName} "+
            $"it has to be required.") 
            {}
    }
}