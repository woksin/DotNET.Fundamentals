/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using Grpc.Core;
using Machine.Specifications;

namespace Dolittle.Services.for_Endpoints.when_starting
{
    public class with_two_service_types_with_different_visibility_two_binders_each : given.two_service_types_with_different_visibility_and_two_binders_each
    {
        static Endpoints endpoints;

        Establish context = () =>
        {
            public_configuration.Enabled = true;
            endpoints = new Endpoints(service_types, endpoints_configuration, type_finder.Object, container.Object, bound_services.Object, logger);
        };

        Because of = () => endpoints.Start();

        It should_start_public_endpoint_once_with_expected_services = () => endpoint.Verify(_ => _.Start(EndpointVisibility.Public, public_configuration, new []
        {
            first_service_type_first_binder_first_service,
            first_service_type_first_binder_second_service,
            first_service_type_second_binder_first_service,
            first_service_type_second_binder_second_service
        }), Moq.Times.Once);

        It should_start_private_endpoint_once_with_expected_services = () => endpoint.Verify(_ => _.Start(EndpointVisibility.Private, private_configuration, new []
        {
            second_service_type_first_binder_first_service,
            second_service_type_first_binder_second_service,
            second_service_type_second_binder_first_service,
            second_service_type_second_binder_second_service
        }), Moq.Times.Once);
    }
}