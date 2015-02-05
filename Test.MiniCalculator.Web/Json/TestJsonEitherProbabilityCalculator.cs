using System;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using MiniCalculator.Json;
using MiniCalculator.Logic.Calculator;

namespace Test.MiniCalculator.Web.Json
{
    [TestFixture]
    class TestJsonEitherProbabilityCalculator
    {
        [Test]
        public void Rerurns_calculator_result_from_EitherProbabilityCalculator()
        {
            this.mockEitherProbabilityCalculator
                .Setup(p => p.Evaluate(0.3f, 0.2f))
                .Returns(0.44f);

            var jsonResponse = this.calculator.Evaluate(0.3f, 0.2f);

            jsonResponse.Successful.Should().BeTrue();
            jsonResponse.CalculationResult.Should().BeApproximately(0.44f, 0.0000001f);
        }

        [Test]
        public void Returns_error_message_if_exception_was_thrown()
        {
            this.mockEitherProbabilityCalculator
                .Setup(p => p.Evaluate(It.IsAny<float>(), It.IsAny<float>()))
                .Throws(new Exception("invalid input"));

            var jsonResponse = this.calculator.Evaluate(0.3f, 0.2f);

            jsonResponse.Successful.Should().BeFalse();
            jsonResponse.ErrorMessage.Should().Be("invalid input");
        }

        [SetUp]
        public void Setup()
        {
            this.mockEitherProbabilityCalculator = new Mock<IEitherProbabilityCalculator>();

            this.calculator = new JsonEitherProbabilityCalculator(this.mockEitherProbabilityCalculator.Object);
        }

        private IJsonEitherProbabilityCalculator calculator;
        private Mock<IEitherProbabilityCalculator> mockEitherProbabilityCalculator;
    }
}
