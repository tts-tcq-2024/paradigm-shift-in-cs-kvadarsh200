using System;

namespace paradigm_shift_csharp
{
    public static class RangeChecker
    {
        public static bool IsOutOfRange(float value, float lowerLimit, float upperLimit)
        {
            return value < lowerLimit || value > upperLimit;
        }
    }
}
