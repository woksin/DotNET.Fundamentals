/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace Dolittle.Applications
{
    /// <summary>
    /// Defines the structure of an application
    /// </summary>
    public interface IApplicationStructure
    {
        /// <summary>
        /// Gets the root <see cref="IApplicationStructureFragment">location fragment definition</see>
        /// </summary>
        IApplicationStructureFragment Root { get; }

        /// <summary>
        /// Checks whether or not the <see cref="IApplicationStructure"/> is a valid structure for an <see cref="IApplication"/>.
        /// It also returns an appropriate exception of what went wrong during the building of the <see cref="IApplicationStructure"/>
        /// if the <see cref="IApplicationStructure"/> is not valid
        /// </summary>
        /// <returns>A <see cref="bool"/> indicating if the <see cref="IApplicationStructure"/> is valid and the related 
        /// <see cref="Exception"/> that should get thrown indicating what went wrong.</returns>
        (bool, Exception) IsValid();
    }
}
