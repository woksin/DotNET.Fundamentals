using System.Collections.Generic;
using Machine.Specifications;

namespace Dolittle.Booting.for_BootStageBuilder.given
{
    public class initial_associations : an_empty_boot_stage_builder
    {
        protected const string first_key = "FirstKey";
        protected const string second_key = "SecondKey";
        protected static object first_value = "FirstValue";

        protected static object second_value = "SecondValue";

        Establish context = () => 
        {
            builder = new BootStageBuilder(initialAssociations:new Dictionary<string, object> {
                { first_key, first_value },
                { second_key, second_value }
            });
        };
    }
}