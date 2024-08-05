using System;
using System.Collections.Generic;

namespace paradigm_shift_csharp
{
    class Notifier
    {
        private static readonly Dictionary<string, float> Tolerances = new Dictionary<string, float>
        {
            { "Temperature", Constants.TempWarningTolerance },
            { "State of Charge", Constants.SocWarningTolerance },
            { "Charge Rate", Constants.ChargeRateWarningTolerance }
        };

        public void PrintWarning(float value, float lowerLimit, float upperLimit, string parameterName)
        {
            float tolerance = GetTolerance(parameterName);
            if (value <= lowerLimit + tolerance)
            {
                Console.WriteLine($"Warning: {parameterName} approaching discharge");
            }
            if (value >= upperLimit - tolerance)
            {
                Console.WriteLine($"Warning: {parameterName} approaching charge-peak");
            }
        }

        private float GetTolerance(string parameterName)
        {
            if (Tolerances.TryGetValue(parameterName, out float tolerance))
            {
                return tolerance;
            }
            throw new ArgumentException("Unknown parameter name");
        }
    }
}
