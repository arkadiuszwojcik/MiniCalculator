using System.Web.Mvc;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using MiniCalculator.Controllers;
using MiniCalculator.Json;

namespace Test.MiniCalculator.Web.Controllers
{
    [TestFixture]
    class TestCalculatorController
    {
        [Test]
        public void Index_returns_caluclator_view()
        {
            this.controller.Index()
                .As<ViewResult>()
                .ViewName.Should().Be("Calculator");
        }

        [Test]
        public void Combined_returns_json_respone_using_JsonCombinedProbabilityCalculator()
        {
            var jsonResponse = new JsonResponse();

            this.mockJsonCombinedProbabilityCalculator
                .Setup(p => p.Evaluate(0.2f, 0.3f))
                .Returns(jsonResponse);

            this.controller.Combined(0.2f, 0.3f)
                .As<JsonResult>()
                .Data.Should().BeSameAs(jsonResponse);
        }

        [Test]
        public void Either_returns_json_respone_using_JsonEitherProbabilityCalculator()
        {
            var jsonResponse = new JsonResponse();

            this.mockJsonEitherProbabilityCalculator
                .Setup(p => p.Evaluate(0.2f, 0.3f))
                .Returns(jsonResponse);

            this.controller.Either(0.2f, 0.3f)
                .As<JsonResult>()
                .Data.Should().BeSameAs(jsonResponse);
        }

        [SetUp]
        public void Setup()
        {
            this.mockJsonCombinedProbabilityCalculator = new Mock<IJsonCombinedProbabilityCalculator>();
            this.mockJsonEitherProbabilityCalculator = new Mock<IJsonEitherProbabilityCalculator>();

            this.controller = new CalculatorController(
                this.mockJsonCombinedProbabilityCalculator.Object,
                this.mockJsonEitherProbabilityCalculator.Object);
        }

        private Mock<IJsonCombinedProbabilityCalculator> mockJsonCombinedProbabilityCalculator;
        private Mock<IJsonEitherProbabilityCalculator> mockJsonEitherProbabilityCalculator;
        private CalculatorController controller;
    }
}
