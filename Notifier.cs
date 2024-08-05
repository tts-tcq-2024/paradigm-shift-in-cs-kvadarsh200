using System;

namespace paradigm_shift_csharp
{
    class Notifier
    {
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
            switch (parameterName)
            {
                case "Temperature": return Constants.TempWarningTolerance;
                case "State of Charge": return Constants.SocWarningTolerance;
                case "Charge Rate": return Constants.ChargeRateWarningTolerance;
                default: throw new ArgumentException("Unknown parameter name");
            }
        }
    }
}
