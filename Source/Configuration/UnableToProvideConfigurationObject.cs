/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Dolittle.Configuration
{
    /// <summary>
    /// Exception that gets thrown when a <see cref="ICanProvideConfigurationObjects">provider</see> is not able to provide
    /// an instance of <see cref="IConfigurationObject"/>
    /// </summary>
    public class UnableToProvideConfigurationObject<TProvider> : Exception
        where TProvider:ICanProvideConfigurationObjects
    {
        /// <summary>
        /// Initialize a new instance of <see cref="UnableToProvideConfigurationObject{TProvider}"/>
        /// </summary>
        /// <param name="type"><see cref="Type"/> of <see cref="IConfigurationObject"/> that is attempted to be provided</param>
        public UnableToProvideConfigurationObject(Type type) 
            : base($"'{typeof(TProvider).AssemblyQualifiedName}' is unable to provide '{type.GetFriendlyConfigurationName()}' - '{type.AssemblyQualifiedName}'")

        {
        }
    }
}