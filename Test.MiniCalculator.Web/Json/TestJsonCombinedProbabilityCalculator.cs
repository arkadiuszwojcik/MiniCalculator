using System;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using MiniCalculator.Json;
using MiniCalculator.Logic.Calculator;

namespace TestMiniCalculator.Web.Json
{
    [TestFixture]
    class TestJsonCombinedProbabilityCalculator
    {
        [Test]
        public void Rerurns_calculator_result_from_CombinedProbabilityCalculator()
        {
            this.mockCombinedProbabilityCalculator
                .Setup(p => p.Evaluate(0.3f, 0.2f))
                .Returns(0.44f);

            var jsonResponse = this.calculator.Evaluate(0.3f, 0.2f);

            jsonResponse.Successful.Should().BeTrue();
            jsonResponse.CalculationResult.Should().BeApproximately(0.44f, 0.0000001f);
        }

        [Test]
        public void Returns_error_message_if_exception_was_thrown()
        {
            this.mockCombinedProbabilityCalculator
                .Setup(p => p.Evaluate(It.IsAny<float>(), It.IsAny<float>()))
                .Throws(new Exception("invalid input"));

            var jsonResponse = this.calculator.Evaluate(0.3f, 0.2f);

            jsonResponse.Successful.Should().BeFalse();
            jsonResponse.ErrorMessage.Should().Be("invalid input");
        }

        [SetUp]
        public void Setup()
        {
            this.mockCombinedProbabilityCalculator = new Mock<ICombinedProbabilityCalculator>();

            this.calculator = new JsonCombinedProbabilityCalculator(this.mockCombinedProbabilityCalculator.Object);
        }

        private IJsonCombinedProbabilityCalculator calculator;
        private Mock<ICombinedProbabilityCalculator> mockCombinedProbabilityCalculator;
    }
}
