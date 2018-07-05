using System;
using Machine.Specifications;

namespace Dolittle.Applications.Specs.for_ApplicationArtifactIdentifierStringConverter.for_2_required_and_1_optional_segment
{
    public class when_converting_string_identifier_with_1_location_segment : given.an_ApplicationArtifactStringConverter
    {
        const string resource_name = "Resource";
        const string location_name = "Location";
         static string string_identifier =
            $"{application_name}{ApplicationArtifactIdentifierStringConverter.ApplicationSeparator}" +
            $"{location_name}" +
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactSeparator}{resource_name}"+
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactTypeSeparator}{artifact_type_name}"+
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactGenerationSeperator}{1}";
        
        static Exception result;

        Because of = () => result = Catch.Exception(() => converter.FromString(string_identifier));

        It should_throw_ApplicationArtifactIdentfierLocationDoesNotMatchApplicationStructure = () => 
            result.ShouldBeOfExactType(typeof(ApplicationArtifactIdentfierLocationDoesNotMatchApplicationStructure));

    }
}