using Machine.Specifications;

namespace Dolittle.DependencyInversion.for_BindingProviderBuilder.given
{
    public class a_binding_provider_builder
    {
        protected static BindingProviderBuilder builder;

        Establish context = () => builder = new BindingProviderBuilder();
    }
}