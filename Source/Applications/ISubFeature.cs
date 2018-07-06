﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Dolittle.Applications
{
    /// <summary>
    /// Defines a <see cref="Feature">feature</see> inside a <see cref="Feature">feature</see>
    /// </summary>
    public interface ISubFeature : IFeature, IBelongToAnApplicationLocationSegmentTypeOf<IFeature>, 
        IAmARecursiveStructureFragmentType
    {
    }
}
