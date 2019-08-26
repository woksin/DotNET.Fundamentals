/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Lifecycle;

namespace Dolittle.Resilience
{
    /// <summary>
    /// Represents an implementation of <see cref="IPolicies"/>
    /// </summary>
    [Singleton]
    public class Policies : IPolicies
    {
        /// <inheritdoc/>
        public IPolicy GetDefault()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public IPolicy GetFor<T>()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public IPolicy GetNamed(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}