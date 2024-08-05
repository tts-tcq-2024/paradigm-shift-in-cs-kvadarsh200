namespace paradigm_shift_csharp
{
    static class Extensions
    {
        public static bool IsOutOfRange(this float value, float lowerLimit, float upperLimit)
        {
            return value < lowerLimit || value > upperLimit;
        }
    }
}
