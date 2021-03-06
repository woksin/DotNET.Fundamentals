/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dolittle.Resilience.Specs.for_Policy
{
    public class when_executing_action_with_no_result_with_delegated_policy
    {
        static Policy policy;
        static Mock<IPolicy> delegated_policy;

        Establish context = () => 
        {
            delegated_policy = new Mock<IPolicy>();
            policy = new Policy(delegated_policy.Object);
        };

        Because of = () => policy.Execute(() => {});

        It should_forward_call_to_delegated_policy = () => delegated_policy.Verify(_ => _.Execute(Moq.It.IsAny<Action>()), Times.Once);
    }
}