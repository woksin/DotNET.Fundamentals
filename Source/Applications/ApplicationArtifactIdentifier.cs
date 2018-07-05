﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dolittle.Artifacts;
using Dolittle.Collections;

namespace Dolittle.Applications
{
    /// <summary>
    /// Represents an implementation of <see cref="IApplicationArtifactIdentifier"/> - an identifier for <see cref="IArtifact">resources</see> in an <see cref="IApplication"/>
    /// </summary>
    public class ApplicationArtifactIdentifier : IApplicationArtifactIdentifier
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationArtifactIdentifier"/>
        /// </summary>
        /// <param name="application"><see cref="IApplication"/> the resource belongs to</param>
        /// <param name="location"><see cref="IApplicationLocation">Location</see> for the <see cref="IArtifact"/></param>
        /// <param name="artifact"><see cref="IArtifact">Artifact</see> the identifier is for</param>
        public ApplicationArtifactIdentifier(
            IApplication application,
            IApplicationLocation location,
            IArtifact artifact)
        {
            Application = application;
            Location = location;
            Artifact = artifact;

            ThrowIfLocationStructureDoesNotMatchApplicationStructure(location);
        }

        /// <inheritdoc/>
        public IApplication Application { get; }

        /// <inheritdoc/>
        public IApplicationLocation Location { get; }

        /// <inheritdoc/>
        public IArtifact Artifact { get; }

        /// <inheritdoc/>
        public static bool operator ==(ApplicationArtifactIdentifier x, ApplicationArtifactIdentifier y)
        {
            return x.Equals(y);
        }

        /// <inheritdoc/>
        public static bool operator !=(ApplicationArtifactIdentifier x, ApplicationArtifactIdentifier y)
        {
            return !x.Equals(y);
        }

        /// <inheritdoc/>
        public bool Equals(IApplicationArtifactIdentifier other)
        {
            if (!Location.Equals(other.Location)) return false;

            if (Application.Name.Value != other.Application.Name.Value) return false;

            if (Artifact != other.Artifact) return false;

            return true;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = Application.GetHashCode();
            hashCode += Location.GetHashCode();
            hashCode += Artifact.GetHashCode();

            return hashCode;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (!(obj is IApplicationArtifactIdentifier)) return false;
            return Equals((IApplicationArtifactIdentifier) obj);
        }

        /// <inheritdoc/>
        public int CompareTo(object obj)
        {
            return GetHashCode().CompareTo(obj.GetHashCode());
        }

        /// <inheritdoc/>
        public int CompareTo(IApplicationArtifactIdentifier other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }

        /// <inheritdoc/>
        public override string ToString() 
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Application.Name.ToString());
            stringBuilder.Append($" - {Artifact.Name.ToString()}");
            stringBuilder.Append($" @ {Location.ToString()}");
           
            return stringBuilder.ToString();
        }

        // Comment, it's really hard to figure out if the Location strcture matches the application structure when the
        // IApplicationStructure can be so loosly defined. Particularry hard to validate when the we can have recursive
        // fragments in the "middle" of an ApplicationStructure
        void ThrowIfLocationStructureDoesNotMatchApplicationStructure(IApplicationLocation location)
        {
            ThrowIfEmptyLocationStructure(location);
            
            IApplicationStructureFragment root;

            root = Application.Structure.Root;

            foreach (var locationSegment in location.Segments)
            {
                if (root == null 
                    || root is NullApplicationStructureFragment)
                {
                    throw new ApplicationArtifactIdentfierLocationDoesNotMatchApplicationStructure(Application.Structure, location);
                }

            }
        }

        void ThrowIfEmptyLocationStructure(IApplicationLocation location)
        {
            if (location.Segments.Count() == 0 &&
                !(Application.Structure is NullApplicationStructure) || 
                !(Application.Structure.Root is NullApplicationStructureFragment))
            {
                throw new ApplicationArtifactIdentfierLocationDoesNotMatchApplicationStructure(Application.Structure, location);
            }
        }
    }
}