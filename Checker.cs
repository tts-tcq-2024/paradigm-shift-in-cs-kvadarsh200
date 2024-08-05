using System;
using paradigm_shift_csharp;
namespace paradigm_shift_csharp
{

    public class Checker
    {
        private readonly IWarningLogger _logger;

        public Checker(IWarningLogger logger)
        {
            _logger = logger;
        }

        public bool CheckTemperature(float temperature)
        {
            bool status = !RangeChecker.IsOutOfRange(temperature, Constants.TempLowerLimit, Constants.TempUpperLimit);
            WarningPrinter.PrintWarning(_logger, temperature, Constants.TempLowerLimit, Constants.TempUpperLimit, Constants.TempWarningTolerance, "Temperature");
            return status;
        }

        public bool CheckSoc(float soc)
        {
            bool status = !RangeChecker.IsOutOfRange(soc, Constants.SocLowerLimit, Constants.SocUpperLimit);
            WarningPrinter.PrintWarning(_logger, soc, Constants.SocLowerLimit, Constants.SocUpperLimit, Constants.SocWarningTolerance, "State of Charge");
            return status;
        }

        public bool CheckChargeRate(float chargeRate)
        {
            bool status = chargeRate <= Constants.ChargeRateUpperLimit;
            if (chargeRate >= Constants.ChargeRateUpperLimit - Constants.ChargeRateWarningTolerance)
            {
                _logger.LogWarning("Warning: Charge Rate approaching charge-peak");
            }
            return status;
        }

        public bool BatteryIsOk(float temperature, float soc, float chargeRate)
        {
            return CheckTemperature(temperature) && CheckSoc(soc) && CheckChargeRate(chargeRate);
        }
    }

}
