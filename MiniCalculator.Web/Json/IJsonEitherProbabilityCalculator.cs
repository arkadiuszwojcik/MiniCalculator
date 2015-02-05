namespace MiniCalculator.Json
{
    public interface IJsonEitherProbabilityCalculator
    {
        JsonResponse Evaluate(float probabilityA, float probabilityB);
    }
}
