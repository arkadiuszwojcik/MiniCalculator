using System;
using MiniCalculator.Library.Extensions;

namespace MiniCalculator.Logic.Calculator
{
    public class EitherProbabilityCalculator : IEitherProbabilityCalculator
    {
        public float Evaluate(float probabilityA, float probabilityB)
        {
            if (!probabilityA.IsInRange(0f, 1f)) throw new ArgumentException("Probability A not in 0 - 1 range");
            if (!probabilityB.IsInRange(0f, 1f)) throw new ArgumentException("Probability B not in 0 - 1 range");

            return probabilityA + probabilityB - probabilityA * probabilityB;
        }
    }
}
