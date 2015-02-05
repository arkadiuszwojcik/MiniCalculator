using System;
using MiniCalculator.Logic.Calculator;

namespace MiniCalculator.Json
{
    class JsonEitherProbabilityCalculator : IJsonEitherProbabilityCalculator
    {
        public JsonEitherProbabilityCalculator(IEitherProbabilityCalculator eitherProbabilityCalculator)
        {
            this.eitherProbabilityCalculator = eitherProbabilityCalculator;
        }

        public JsonResponse Evaluate(float probabilityA, float probabilityB)
        {
            var response = new JsonResponse();

            try
            {
                response.CalculationResult = this.eitherProbabilityCalculator.Evaluate(probabilityA, probabilityB);
                response.Successful = true;
            }
            catch (Exception ex)
            {
                response.Successful = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        private readonly IEitherProbabilityCalculator eitherProbabilityCalculator;
    }
}
