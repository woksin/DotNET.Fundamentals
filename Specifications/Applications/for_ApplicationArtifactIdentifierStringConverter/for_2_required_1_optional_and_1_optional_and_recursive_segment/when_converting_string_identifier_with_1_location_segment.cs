﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using Machine.Specifications;
using It = Machine.Specifications.It;

namespace Dolittle.Applications.Specs.for_ApplicationArtifactIdentifierStringConverter.for_2_required_1_optional_and_1_optional_and_recursive_segment
{
    public class when_converting_string_identifier_with_1_location_segment : given.an_application_resource_identifier_converter
    {
        const string bounded_context = "TheBoundedContext";
        const string resource_name = "MyResource";
        const int artifact_generation = 1;

        static string string_identifier =
            $"{application_name}{ApplicationArtifactIdentifierStringConverter.ApplicationSeparator}" +
            $"{bounded_context}" +
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactSeparator}{resource_name}"+
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactTypeSeparator}{artifact_type_name}"+
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactGenerationSeperator}{artifact_generation}";

        static Exception result;

        Because module_is_required_but_missing = () => result = Catch.Exception(() => converter.FromString(string_identifier));

        It should_throw_an_ApplicationArtifactIdentfierLocationDoesNotMatchApplicationStructure = () => 
            result.ShouldBeOfExactType(typeof(ApplicationArtifactIdentfierLocationDoesNotMatchApplicationStructure));

        

    }
}