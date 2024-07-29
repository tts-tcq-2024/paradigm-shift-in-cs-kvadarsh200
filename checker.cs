using System;

namespace ParadigmShift
{
    public enum StatusType
    {
        Normal,
        Warning,
        Breach
    }

    public class checker
    {
        private static StatusType GetStatus(float value, float lowerLimit, float upperLimit)
        {
            float lowerWarningThreshold = lowerLimit + upperLimit * GlobalSettings.WarningTolerance;
            float upperWarningThreshold = upperLimit - upperLimit * GlobalSettings.WarningTolerance;

            if (value < lowerLimit || value > upperLimit)
            {
                return StatusType.Breach;
            }
            else if (value <= lowerWarningThreshold || value >= upperWarningThreshold)
            {
                return StatusType.Warning;
            }
            return StatusType.Normal;
        }

        public static StatusType CheckTemperatureStatus(float temperature)
        {
            return GetStatus(temperature, 0, 45);
        }

        public static StatusType CheckSocStatus(float soc)
        {
            return GetStatus(soc, 20, 80);
        }

        public static StatusType CheckChargeRateStatus(float chargeRate)
        {
            return GetStatus(chargeRate, 0, 0.8f);
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
