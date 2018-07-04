﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Machine.Specifications;
using It = Machine.Specifications.It;

namespace Dolittle.Applications.Specs.for_ApplicationArtifactIdentifierStringConverter.for_application_structure_with_4_correct_segments
{
    public class when_converting_string_identifier_missing_application_separator_in_string : given.an_application_resource_identifier_converter
    {
        static string string_identifier = "Application";
        static Exception exception;

        Because of = () => exception = Catch.Exception(() => converter.FromString(string_identifier));

        It should_throw_unable_to_identify_application = () => exception.ShouldBeOfExactType<UnableToIdentifyApplication>();
    }
}
