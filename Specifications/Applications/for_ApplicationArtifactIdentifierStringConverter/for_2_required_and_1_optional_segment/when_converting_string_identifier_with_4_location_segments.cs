/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using Machine.Specifications;
using It = Machine.Specifications.It;

namespace Dolittle.Applications.Specs.for_ApplicationArtifactIdentifierStringConverter.for_2_required_and_1_optional_segment
{
    public class when_converting_string_identifier_with_4_location_segments : given.an_ApplicationArtifactStringConverter
    {
        const string bounded_context_name = "TheBoundedContext";
        const string module_name = "TheModule";
        const string feature_name = "TheFeature";
        const string sub_feature_name = "TheSubFeature";
        const string resource_name = "MyResource";
        const int artifact_generation = 1;

        static string string_identifier =
            $"{application_name}{ApplicationArtifactIdentifierStringConverter.ApplicationSeparator}" +
            $"{bounded_context_name}{ApplicationArtifactIdentifierStringConverter.ApplicationLocationSeparator}" +
            $"{module_name}{ApplicationArtifactIdentifierStringConverter.ApplicationLocationSeparator}" +
            $"{feature_name}{ApplicationArtifactIdentifierStringConverter.ApplicationLocationSeparator}" +
            $"{sub_feature_name}" +
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactSeparator}{resource_name}"+
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactTypeSeparator}{artifact_type_name}"+
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactGenerationSeperator}{artifact_generation}";

        static Exception result;

        Because of = () => result = Catch.Exception(() => converter.FromString(string_identifier));

        It should_throw_ApplicationArtifactIdentfierLocationDoesNotMatchApplicationStructure = () => 
            result.ShouldBeOfExactType(typeof(ApplicationArtifactIdentfierLocationDoesNotMatchApplicationStructure));
    }
}
