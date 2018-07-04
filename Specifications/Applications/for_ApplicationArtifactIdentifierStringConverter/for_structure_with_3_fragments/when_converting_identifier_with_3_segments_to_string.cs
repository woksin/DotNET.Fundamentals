using Dolittle.Artifacts;
using Machine.Specifications;


namespace Dolittle.Applications.Specs.for_ApplicationArtifactIdentifierStringConverter.for_structure_with_3_fragments
{
    public class when_converting_identifier_with_3_segments_to_string : given.an_ApplicationArtifactStringConverter
    {
        const string bounded_context_name = "TheBoundedContext";
        const string module_name = "TheModule";
        const string feature_name = "TheFeature";
        const string artifact_name = "MyResource";
        const int artifact_generation = 1;

        static string expected =
            $"{application_name}{ApplicationArtifactIdentifierStringConverter.ApplicationSeparator}" +
            $"{bounded_context_name}{ApplicationArtifactIdentifierStringConverter.ApplicationLocationSeparator}" +
            $"{module_name}{ApplicationArtifactIdentifierStringConverter.ApplicationLocationSeparator}" +
            $"{feature_name}{ApplicationArtifactIdentifierStringConverter.ApplicationLocationSeparator}" +
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactSeparator}{artifact_name}" +
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactTypeSeparator}{artifact_type_name}" +
            $"{ApplicationArtifactIdentifierStringConverter.ApplicationArtifactGenerationSeperator}{artifact_generation}";

        static IApplicationArtifactIdentifier identifier;

        static string result;

        Establish context = () =>
        {
            var bounded_context = new BoundedContext(bounded_context_name);
            var module = new Module(bounded_context, module_name);
            var feature = new Feature(module, feature_name);

            var location = new Moq.Mock<IApplicationLocation>();
            location.SetupGet(_ => _.Segments).Returns(new IApplicationLocationSegment[] {
                bounded_context,
                module,
                feature
            });

            var artifact = new Artifact(artifact_name, artifact_type.Object, artifact_generation);
            identifier = new ApplicationArtifactIdentifier(
                application,
                location.Object,
                artifact);
        };

        Because of = () => result = converter.AsString(identifier);

        It should_be_the_same_string = () => result.ShouldEqual(result);
    }
}