using System;

namespace paradigm_shift_csharp
{
    class RangeChecker
    {
        private readonly Notifier _notifier;
        public RangeChecker()
        {
            _notifier = new Notifier();
        }

        public bool Check(float value, float lowerLimit, float upperLimit, string parameterName)
        {
            if (value.IsOutOfRange(lowerLimit, upperLimit))
            {
                Console.WriteLine($"{parameter} is out of range!");
                return false;
            }
            _notifier.PrintWarning(value, lowerLimit, upperLimit, parameterName);
            return true;
        }

        public bool CheckChargeRate(float chargeRate)
        {
            if (chargeRate > Constants.ChargeRateUpperLimit)
            {
                Console.WriteLine("Charge Rate is out of range!");
                return false;
            }
            if (chargeRate >= Constants.ChargeRateUpperLimit - Constants.ChargeRateWarningTolerance)
            {
                Console.WriteLine("Warning: Approaching charge-peak");
            }
            return true;
        }
    }
}
