﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/

namespace Dolittle.PropertyBags.Migrations
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class NullPropertyName : ArgumentNullException
    {
        /// <summary>
        ///     Initializes a new instance of the InvalidMigrationSource custom exception
        /// </summary>
        /// <param name="message">A message describing the exception</param>
        public NullPropertyName(string message)
            : base(message)
        {}

        /// <summary>
        ///     Initializes a new instance of the InvalidMigrationSource custom exception
        /// </summary>
        /// <param name="message">A message describing the exception</param>
        /// <param name="innerException">An inner exception that is the original source of the error</param>
        public NullPropertyName(string message, Exception innerException)
            : base(message, innerException)
        {}

        /// <summary>
        ///     Initializes a new instance of the InvalidMigrationSource custom exception
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the object data of the exception</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination</param>
        protected NullPropertyName(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {}
    }
}