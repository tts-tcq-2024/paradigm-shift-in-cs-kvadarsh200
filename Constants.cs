namespace paradigm_shift_csharp
{
    static class Constants
    {
        public const float TempLowerLimit = 0;
        public const float TempUpperLimit = 45;
        public const float SocLowerLimit = 20;
        public const float SocUpperLimit = 80;
        public const float ChargeRateUpperLimit = 0.8f;

        public const float TempWarningTolerance = TempUpperLimit * 0.05f;
        public const float SocWarningTolerance = SocUpperLimit * 0.05f;
        public const float ChargeRateWarningTolerance = ChargeRateUpperLimit * 0.05f;
    }
}
