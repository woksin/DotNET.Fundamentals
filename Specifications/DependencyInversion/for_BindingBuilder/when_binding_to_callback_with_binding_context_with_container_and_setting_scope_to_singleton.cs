using System;
using Machine.Specifications;

namespace Dolittle.DependencyInversion.for_BindingBuilder
{
    public class when_binding_to_callback_with_binding_context_with_container_and_setting_scope_to_singleton : given.a_null_binding
    {
        static Binding result;
        static Func<BindingContext, object> callback = (bindingContext) => "result";

        Because of = () => 
        {
            builder.To(callback).Singleton();
            result = builder.Build();
        };

        It should_have_a_callback_strategy = () => result.Strategy.ShouldBeOfExactType<Strategies.CallbackWithBindingContext>();
        It should_hold_the_delegate_in_the_strategy = () => ((Strategies.CallbackWithBindingContext)result.Strategy).Target.ShouldEqual(callback);
        It should_have_singleton_scope = () => result.Scope.ShouldBeAssignableTo<Scopes.Singleton>();
    }
}