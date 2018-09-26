﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Concepts;

namespace Dolittle.Tenancy
{
    /// <summary>
    /// Represents the concept of a tenant
    /// </summary>
    public class TenantId : ConceptAs<Guid>
    {
        /// <summary>
        /// Gets the definition of an unknown tenant
        /// </summary>
        public static readonly TenantId Unknown = Guid.Parse("762a4bd5-2ee8-4d33-af06-95806fb73f4e");

        /// <summary>
        /// Implicitly convert from <see cref="Guid"/> to <see cref="TenantId"/>
        /// </summary>
        /// <param name="tenantId"></param>
        public static implicit operator TenantId(Guid tenantId)
        {
            return new TenantId { Value = tenantId };
        }
    }
}
