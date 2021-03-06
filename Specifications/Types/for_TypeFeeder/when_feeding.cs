﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Reflection;
using Dolittle.Assemblies;
using Dolittle.Logging;
using Dolittle.Scheduling;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dolittle.Types.Specs.for_TypeFeeder
{
    [Subject(typeof(TypeFeeder))]
    public class when_feeding
    {
        static Mock<Assembly> assembly_mock;
        static Mock<IAssemblies> assemblies_mock;
        protected static Type[] types;
        static Mock<IContractToImplementorsMap> contract_to_implementors_map_mock;

        static TypeFeeder type_feeder;

        Establish context = () =>
        {
            types = new[] {
                typeof(ISingle),
                typeof(Single),
                typeof(IMultiple),
                typeof(FirstMultiple),
                typeof(SecondMultiple)
            };

            assembly_mock = new Mock<Assembly>();
            assembly_mock.Setup(a => a.GetTypes()).Returns(types);
            assembly_mock.Setup(a => a.FullName).Returns("A.Full.Name");

            assemblies_mock = new Mock<IAssemblies>();
            assemblies_mock.Setup(x => x.GetAll()).Returns(new[] { assembly_mock.Object });

            contract_to_implementors_map_mock = new Mock<IContractToImplementorsMap>();
            contract_to_implementors_map_mock.SetupGet(c => c.All).Returns(types);

            type_feeder = new TypeFeeder(new SyncScheduler(), Mock.Of<ILogger>());
        };     

        Because of = () => type_feeder.Feed(assemblies_mock.Object, contract_to_implementors_map_mock.Object);

        It should_populate_map = () => contract_to_implementors_map_mock.Verify(c=>c.Feed(types), Times.Once);
    }
}