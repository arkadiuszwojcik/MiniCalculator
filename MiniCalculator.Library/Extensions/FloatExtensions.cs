using System;

namespace MiniCalculator.Library.Extensions
{
    public static class FloatExtensions
    {
        public static bool IsInRange(this float value, float min, float max)
        {
            if (min > max) throw new ArgumentException("Min value should be less than max");

            return value >= min && value <= max;
        }
    }
}
