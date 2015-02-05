using System;
using MiniCalculator.Logic.Calculator;

namespace MiniCalculator.Json
{
    class JsonCombinedProbabilityCalculator : IJsonCombinedProbabilityCalculator
    {
        public JsonCombinedProbabilityCalculator(ICombinedProbabilityCalculator combinedProbabilityCalculator)
        {
            this.combinedProbabilityCalculator = combinedProbabilityCalculator;
        }

        public JsonResponse Evaluate(float probabilityA, float probabilityB)
        {
            var response = new JsonResponse();

            try
            {
                response.CalculationResult = this.combinedProbabilityCalculator.Evaluate(probabilityA, probabilityB);
                response.Successful = true;
            }
            catch (Exception ex)
            {
                response.Successful = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        private readonly ICombinedProbabilityCalculator combinedProbabilityCalculator;
    }
}
