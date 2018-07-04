using System;
using Machine.Specifications;

namespace Dolittle.Applications.Specs.for_ApplicationArtifactIdentifierStringConverter.for_structure_with_3_fragments
{
    public class when_missing_BoundedContext : given.an_ApplicationArtifactStringConverter
    {
        const string resource_name = "Resource";
        const string module_name = "Module";
        const string feature_name = "Feature";
         static string string_identifier =
            $"{application_name}{ApplicationArtifactIdentifierStringConverter.ApplicationSeparator}" +
            $"{module_name}{ApplicationArtifactIdentifierStringConverter.ApplicationLocationSeparator}" +
            $"{feature_name}{ApplicationArtifactIdentifierStringConverter.ApplicationLocationSeparator}" +
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactSeparator}{resource_name}"+
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactTypeSeparator}{artifact_type_name}"+
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactGenerationSeperator}{1}";
        
        static Exception exception;

        Because of = () => exception = Catch.Exception(() => converter.FromString(string_identifier));

        // It should throw an exception saying ArtifactIdentiferString does not match the Application's Structure

    }
}