namespace MiniCalculator.Json
{
    public class JsonResponse
    {
        public float CalculationResult { get; set; }
        public bool Successful { get; set; }
        public string ErrorMessage { get; set; }
    }
}
