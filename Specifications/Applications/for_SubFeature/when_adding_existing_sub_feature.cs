﻿using System;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dolittle.Applications.Specs.for_SubFeature
{
    public class when_adding_existing_sub_feature
    {
        static Mock<IFeature> parent_feature_mock;
        static SubFeature feature;
        static Mock<ISubFeature> sub_feature_mock;
        static Exception exception;

        Establish context = () =>
        {
            parent_feature_mock = new Mock<IFeature>();
            feature = new SubFeature(parent_feature_mock.Object, new FeatureName {Value = "Some feature"});
            sub_feature_mock = new Mock<ISubFeature>();
            feature.AddSubFeature(sub_feature_mock.Object);
        };

        Because of = () => exception = Catch.Exception(() => feature.AddSubFeature(sub_feature_mock.Object));

        It should_throw_sub_feature_already_added_to_feature = () => exception.ShouldBeOfExactType<SubFeatureAlreadyAddedToFeature>();
    }
}
