using System;
using Machine.Specifications;

namespace Dolittle.Applications.Specs.for_ApplicationArtifactIdentifierStringConverter
{
    public class when_identifier_string_is_missing_application_seperator : given.an_ApplicationArtifactIdentifierStringConverter
    {
        
        static string string_identifier = "Application";
        static Exception exception;

        Because of = () => exception = Catch.Exception(() => converter.FromString(string_identifier));

        It should_throw_unable_to_identify_application = () => exception.ShouldBeOfExactType<UnableToIdentifyApplication>();
    }
}