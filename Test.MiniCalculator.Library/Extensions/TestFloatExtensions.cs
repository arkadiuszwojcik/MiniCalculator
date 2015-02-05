using System;
using NUnit.Framework;
using FluentAssertions;
using MiniCalculator.Library.Extensions;

namespace Test.MiniCalculator.Library.Extensions
{
    [TestFixture]
    class TestFloatExtensions
    {
        [TestCase(2.0f, 1.0f)]
        [TestCase(3.9f, 3.8f)]
        public void Throws_argument_exception_if_max_argument_is_less_than_min(float min, float max)
        {
            Action act = () => 3.5f.IsInRange(min, max);

            act.ShouldThrow<ArgumentException>()
                .WithMessage("Min value should be less than max");
        }

        [TestCase(1.0f, 0.5f, 2.0f)]
        [TestCase(0.5f, 0.5f, 2.0f)]
        [TestCase(2.0f, 0.5f, 2.0f)]
        public void Returns_true_if_value_is_in_range(float value, float min, float max)
        {
            value.IsInRange(min, max).Should().BeTrue();
        }

        [TestCase(0.49f, 0.5f, 2.0f)]
        [TestCase(2.1f, 0.5f, 2.0f)]
        public void Returns_false_if_value_is_not_in_range(float value, float min, float max)
        {
            value.IsInRange(min, max).Should().BeFalse();
        }
    }
}
