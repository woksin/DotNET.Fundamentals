/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace Dolittle.Services
{
    /// <summary>
    /// Defines a host for hosting services for a specific purpose
    /// </summary>
    public interface IEndpoint : IDisposable
    {
        /// <summary>
        /// Start the host with the configuration for it
        /// </summary>
        /// <param name="type"><see cref="EndpointVisibility"/> for the <see cref="IEndpoint"/></param>
        /// <param name="configuration"><see cref="EndpointConfiguration"/> for the host</param>
        /// <param name="services">Collection of <see cref="Service"/> to host</param>
        void Start(EndpointVisibility type, EndpointConfiguration configuration, IEnumerable<Service> services);
    }
}