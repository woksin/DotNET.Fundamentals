using Machine.Specifications;

namespace Dolittle.Specs.Concepts.given
{
    public class concepts
    {
        protected static StringConcept first_string;
        protected static StringConcept second_string;
        protected static StringConcept same_value_as_second_string;
        protected static StringConcept string_is_empty;
        protected static StringConcept string_is_null;
        protected static IntConcept value_as_an_int;
        protected static LongConcept value_as_a_long;
        protected static InheritingFromLongConcept value_as_a_long_inherited;
        protected static InheritingFromLongConcept empty_long_value;


        Establish context = () =>
            {
                first_string = "first";
                second_string = "second";
                same_value_as_second_string = "second";
                string_is_empty = string.Empty;
                string_is_null = new StringConcept();

                value_as_a_long = 1;
                value_as_an_int = 1;
                value_as_a_long_inherited = 1;
                empty_long_value = 0;
            };
    }
}