using Machine.Specifications;

namespace Dolittle.PropertyBags.Specs.for_ObjectFactory.when_building.a_type_with_an_enumerable.for_enumerable_with_primitive_elements
{
    public class when_enumerable_has_elements : given.an_object_factory
    {
        static IObjectFactory factory;
        static EnumerableWithPrimitiveElements enumerable_type;
        static PropertyBag source;
        static EnumerableWithPrimitiveElements result;
        Establish context = () => 
        {
            factory = instance;
            enumerable_type = new EnumerableWithPrimitiveElements();
            enumerable_type.Enumerable = new string[]
            {
                "s1",
                null,
                "s2"
            };
            source = enumerable_type.ToPropertyBag();
        };

        Because of = () => result = factory.Build<EnumerableWithPrimitiveElements>(source);

        It should_build_an_instance_of_the_type = () => result.ShouldBeOfExactType<EnumerableWithPrimitiveElements>();

        It enumerable_should_not_be_null = () => result.Enumerable.ShouldNotBeNull();

        //TODO: CHeck the actual content of the Enumerable
    }
}