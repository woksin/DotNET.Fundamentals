﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Dolittle.Applications
{
    /// <summary>
    /// Defines a module within a <see cref="IBoundedContext"/>
    /// </summary>
    public interface IModule : IApplicationLocationSegment<ModuleName>, IBelongToAnApplicationLocationSegmentTypeOf<IBoundedContext>, ICanHoldApplicationLocationSegmentsOfType<IFeature>,
        IAmARequiredStructureFragmentType
    {
        /// <summary>
        /// Add a feature to the <see cref="Module"/>
        /// </summary>
        /// <param name="feature"></param>
        void AddFeature(IFeature feature);
    }
}
