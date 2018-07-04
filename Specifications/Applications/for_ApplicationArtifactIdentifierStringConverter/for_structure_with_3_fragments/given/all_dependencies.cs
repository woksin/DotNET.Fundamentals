using Machine.Specifications;

namespace Dolittle.Applications.Specs.for_ApplicationArtifactIdentifierStringConverter.for_structure_with_3_fragments.given
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
                            .WithChild<Feature>()))
                .Build();
    }
}