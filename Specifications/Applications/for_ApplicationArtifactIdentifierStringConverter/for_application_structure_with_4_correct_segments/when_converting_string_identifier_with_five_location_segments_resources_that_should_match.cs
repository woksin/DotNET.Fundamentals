﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Machine.Specifications;
using It = Machine.Specifications.It;

namespace Dolittle.Applications.Specs.for_ApplicationArtifactIdentifierStringConverter.for_application_structure_with_4_correct_segments
{
    public class when_converting_string_identifier_with_five_location_segments_resources_that_should_match : given.an_application_resource_identifier_converter
    {
        const string bounded_context_name = "TheBoundedContext";
        const string module_name = "TheModule";
        const string feature_name = "TheFeature";
        const string sub_feature_name = "TheSubFeature";
        const string second_level_sub_feature_name = "TheSecondLevelSubFeature";
        const string resource_name = "MyResource";
        const int artifact_generation = 1;

        static string string_identifier =
            $"{application_name}{ApplicationArtifactIdentifierStringConverter.ApplicationSeparator}" +
            $"{bounded_context_name}{ApplicationArtifactIdentifierStringConverter.ApplicationLocationSeparator}" +
            $"{module_name}{ApplicationArtifactIdentifierStringConverter.ApplicationLocationSeparator}" +
            $"{feature_name}{ApplicationArtifactIdentifierStringConverter.ApplicationLocationSeparator}" +
            $"{sub_feature_name}{ApplicationArtifactIdentifierStringConverter.ApplicationLocationSeparator}" +
            $"{second_level_sub_feature_name}" +
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactSeparator}{resource_name}"+
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactTypeSeparator}{artifact_type_name}"+
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactGenerationSeperator}{artifact_generation}";

        static IApplicationArtifactIdentifier identifier;

        Because of = () => identifier = converter.FromString(string_identifier);

        It should_return_a_matching_identifier = () => identifier.ShouldNotBeNull();
        It should_hold_the_application = () => identifier.Application.ShouldEqual(application);
        It should_hold_the_artifact = () => identifier.Artifact.Name.Value.ShouldEqual(resource_name);
        It should_hold_the_five_segments = () => identifier.Location.Segments.Count().ShouldEqual(5);
        It should_hold_the_bounded_context_segment = () => identifier.Location.Segments.ToArray()[0].Name.AsString().ShouldEqual(bounded_context_name);
        It should_hold_the_module_segment = () => identifier.Location.Segments.ToArray()[1].Name.AsString().ShouldEqual(module_name);
        It should_hold_the_feature_segment = () => identifier.Location.Segments.ToArray()[2].Name.AsString().ShouldEqual(feature_name);
        It should_hold_the_sub_feature_segment = () => identifier.Location.Segments.ToArray()[3].Name.AsString().ShouldEqual(sub_feature_name);
        It should_hold_the_second_level_sub_feature_segment = () => identifier.Location.Segments.ToArray()[4].Name.AsString().ShouldEqual(second_level_sub_feature_name);
        It should_hold_the_artifact_type = () => identifier.Artifact.Type.ShouldEqual(artifact_type.Object);
        It should_hold_the_artifact_generation = () => identifier.Artifact.Generation.Value.ShouldEqual(artifact_generation);
    }
}
