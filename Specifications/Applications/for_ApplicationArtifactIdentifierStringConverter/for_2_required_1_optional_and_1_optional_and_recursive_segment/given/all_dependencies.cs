using Machine.Specifications;

namespace Dolittle.Applications.Specs.for_ApplicationArtifactIdentifierStringConverter.for_2_required_1_optional_and_1_optional_and_recursive_segment.given
{
    public class all_dependencies
    {
        protected const string application_name = "MyApplication";
        protected static IApplication application; 

        Establish context = () => 
            application = 
                Application.WithName(application_name)
                    .WithStructureStartingWith<BoundedContext>(b => 
                        b.Required
                        .WithChild<Module>(m => 
                            m.Required
                            .WithChild<Feature>(f =>
                                f.WithChild<SubFeature>(sf =>
                                    sf.Recursive))))
                .Build();
    }
}