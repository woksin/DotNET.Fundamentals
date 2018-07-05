using System.Linq;
using Machine.Specifications;

namespace Dolittle.Applications.Specs.for_ApplicationArtifactIdentifierStringConverter.for_2_required_and_1_optional_segment
{
    public class when_converting_string_identifier_with_2_location_segments : given.an_ApplicationArtifactStringConverter
    {
        const string bounded_context_name = "TheBoundedContext";
        const string module_name = "TheModule";
        const string resource_name = "MyResource";
        const int artifact_generation = 1;
        
        static string string_identifier =
            $"{application_name}{ApplicationArtifactIdentifierStringConverter.ApplicationSeparator}" +
            $"{bounded_context_name}{ApplicationArtifactIdentifierStringConverter.ApplicationLocationSeparator}" +
            $"{module_name}" +
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactSeparator}{resource_name}"+
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactTypeSeparator}{artifact_type_name}"+
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactGenerationSeperator}{artifact_generation}";

        static IApplicationArtifactIdentifier identifier;

        Because of = () => identifier = converter.FromString(string_identifier);

        It should_return_a_matching_identifier = () => identifier.ShouldNotBeNull();
        It should_hold_the_application = () => identifier.Application.ShouldEqual(application);
        It should_hold_the_artifact = () => identifier.Artifact.Name.Value.ShouldEqual(resource_name);
        It should_hold_the_two_segments = () => identifier.Location.Segments.Count().ShouldEqual(2);
        It should_hold_the_bounded_context_segment = () => identifier.Location.Segments.First().Name.AsString().ShouldEqual(bounded_context_name);
        It should_hold_the_module_segment = () => identifier.Location.Segments.ToArray()[1].Name.AsString().ShouldEqual(module_name);
        It should_hold_the_artifact_type = () => identifier.Artifact.Type.ShouldEqual(artifact_type.Object);
        It should_hold_the_artifact_generation = () => identifier.Artifact.Generation.Value.ShouldEqual(artifact_generation);

    }
}