using System;
using Machine.Specifications;

namespace Dolittle.DependencyInversion.for_BindingBuilder
{
    public class when_binding_to_type_callback_with_binding_contextand_setting_scope_to_singleton_per_tenant : given.a_null_binding
    {
        static Binding result;
        static Func<BindingContext,Type> callback = (c) => typeof(string);

        Because of = () => 
        {
            builder.To(callback).SingletonPerTenant();
            result = builder.Build();
        };

        It should_have_a_callback_strategy = () => result.Strategy.ShouldBeOfExactType<Strategies.TypeCallbackWithBindingContext>();
        It should_hold_the_delegeate_in_the_strategy = () => ((Strategies.TypeCallbackWithBindingContext)result.Strategy).Target.ShouldEqual(callback);
        It should_have_singleton_per_tenant_scope = () => result.Scope.ShouldBeAssignableTo<Scopes.SingletonPerTenant>();
    }
}