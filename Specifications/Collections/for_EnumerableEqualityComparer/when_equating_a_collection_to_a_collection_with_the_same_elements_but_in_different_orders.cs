namespace Dolittle.Collections.for_EnumerableEqualityComparer
{
    using Machine.Specifications;
    using Dolittle.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [Subject(typeof(EnumerableEqualityComparer<>))]
    public class when_equating_a_collection_to_a_collection_with_the_same_elements_but_in_different_orders
    {
        static IEnumerable<int> collection;
        static IEnumerable<int> other;
        static IEqualityComparer<IEnumerable<int>> comparer;
        static bool is_equal;

        Establish context = () => 
        {
            collection = new int[]{1,2,3};
            other = new int[]{3,2,1};
            comparer = new EnumerableEqualityComparer<int>();
        };

        Because of = () => is_equal = comparer.Equals(collection, other);

        It should_not_be_equal = () => is_equal.ShouldBeFalse();
    }
}