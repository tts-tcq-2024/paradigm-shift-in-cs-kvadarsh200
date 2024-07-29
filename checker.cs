using System;
using System.Diagnostics;
namespace paradigm_shift_csharp
{
    public enum StatusType
    {
        Normal,
        Warning,
        Breach
    }
public class Checker
{
   static StatusType CheckTemperatureStatus(float temperature)
        {
            if (temperature < 0)
                return StatusType.Breach;
            else if (temperature >= 0 && temperature <= (0 + 45 * GlobalSettings.WarningTolerance))
                return StatusType.Warning;
            else if (temperature > 45)
                return StatusType.Breach;
            else if (temperature > (45 - 45 * GlobalSettings.WarningTolerance) && temperature <= 45)
                return StatusType.Warning;
            return StatusType.Normal;
        }
     static StatusType CheckSocStatus(float soc)
        {
            float upperLimit = 80;
            float lowerLimit = 20;
            if (soc < lowerLimit)
                return StatusType.Breach;
            else if (soc >= lowerLimit && soc <= (lowerLimit + upperLimit * GlobalSettings.WarningTolerance))
                return StatusType.Warning;
            else if (soc > upperLimit)
                return StatusType.Breach;
            else if (soc > (upperLimit - upperLimit * GlobalSettings.WarningTolerance) && soc <= upperLimit)
                return StatusType.Warning;
            return StatusType.Normal;
        }

        static StatusType CheckChargeRateStatus(float chargeRate)
        {
            float upperLimit = 0.8f;
            if (chargeRate > upperLimit)
                return StatusType.Breach;
            else if (chargeRate > (upperLimit - upperLimit * GlobalSettings.WarningTolerance) && chargeRate <= upperLimit)
                return StatusType.Warning;
            return StatusType.Normal;
        }

        public static void CheckTemperature(float temperature)
        {
            var status = CheckTemperatureStatus(temperature);
            if (status != StatusType.Normal)
                Console.WriteLine(MessageHelper.GetTemperatureMessage(status));
        }

        public static void CheckSoc(float soc)
        {
            var status = CheckSocStatus(soc);
            if (status != StatusType.Normal)
                Console.WriteLine(MessageHelper.GetSocMessage(status));
        }

        public static void CheckChargeRate(float chargeRate)
        {
            var status = CheckChargeRateStatus(chargeRate);
            if (status != StatusType.Normal)
                Console.WriteLine(MessageHelper.GetChargeRateMessage(status));
        }

        public static bool BatteryIsOk(float temperature, float soc, float chargeRate)
        {
            CheckTemperature(temperature);
            CheckSoc(soc);
            CheckChargeRate(chargeRate);
            return (CheckTemperatureStatus(temperature) == StatusType.Normal &&
                    CheckSocStatus(soc) == StatusType.Normal &&
                    CheckChargeRateStatus(chargeRate) == StatusType.Normal);
        }
    
}
}
