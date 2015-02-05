using System;
using NUnit.Framework;
using FluentAssertions;
using MiniCalculator.Logic.Calculator;

namespace Test.MiniCalculator.Logic.Calculator
{
    [TestFixture]
    class TestEitherProbabilityCalculator
    {
        [TestCase(1.1f)]
        [TestCase(-0.1f)]
        public void Throws_argument_exception_if_probability_A_is_not_in_0_1_range(float probabilityA)
        {
            Action act = () => this.calculator.Evaluate(probabilityA, 0.5f);

            act.ShouldThrow<ArgumentException>()
                .WithMessage("Probability A not in 0 - 1 range");
        }

        [TestCase(1.1f)]
        [TestCase(-0.1f)]
        public void Throws_argument_exception_if_probability_B_is_not_in_0_1_range(float probabilityB)
        {
            Action act = () => this.calculator.Evaluate(0.5f, probabilityB);

            act.ShouldThrow<ArgumentException>()
                .WithMessage("Probability B not in 0 - 1 range");
        }

        [TestCase(0.2f, 0.7f, 0.76f)]
        [TestCase(0.25f, 0.63f, 0.7225f)]
        public void Is_evaluating_either_probability(float probabilityA, float probabilityB, float result)
        {
            this.calculator.Evaluate(probabilityA, probabilityB)
                .Should().BeApproximately(result, Epsilon);
        }

        [SetUp]
        public void Setup()
        {
            this.calculator = new EitherProbabilityCalculator();
        }

        private const float Epsilon = 0.0000001f;
        private IEitherProbabilityCalculator calculator;
    }
}
