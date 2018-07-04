using System;

namespace Dolittle.Applications
{
    /// <summary>
    /// An Exception that gets thrown when an <see cref="IApplicationArtifactIdentifier"/> is constructed with an <see cref="IApplicationLocation"/>
    /// that does not match the <see cref="IApplication"/>'s <see cref="IApplicationStructure"/>
    /// </summary>
    public class ApplicationArtifactIdentfierLocationDoesNotMatchApplicationStructure : ArgumentException
    {
        /// <summary>
        /// Initializes the <see cref="ApplicationArtifactIdentfierLocationDoesNotMatchApplicationStructure"/>
        /// </summary>
        public ApplicationArtifactIdentfierLocationDoesNotMatchApplicationStructure(IApplicationStructure structure, IApplicationLocation location)
            : base($"IApplicationLocation {location} does not match IApplicationStructure {structure}")
            {}
    }
}