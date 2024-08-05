namespace paradigm_shift_csharp
{
  public static class WarningPrinter
    {
        public static void PrintWarning(IWarningLogger logger, float value, float lowerLimit, float upperLimit, float tolerance, string parameterName)
        {
            if (value <= lowerLimit + tolerance)
            {
                logger.LogWarning($"Warning: {parameterName} approaching discharge");
            }
            if (value >= upperLimit - tolerance)
            {
                logger.LogWarning($"Warning: {parameterName} approaching charge-peak");
            }
        }
    }
}
