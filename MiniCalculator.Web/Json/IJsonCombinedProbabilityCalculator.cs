namespace MiniCalculator.Json
{
    public interface IJsonCombinedProbabilityCalculator
    {
        JsonResponse Evaluate(float probabilityA, float probabilityB);
    }
}
