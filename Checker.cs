using System;

namespace paradigm_shift_csharp
{
    class Checker
    {
        const float TempLowerLimit = 0;
        const float TempUpperLimit = 45;
        const float SocLowerLimit = 20;
        const float SocUpperLimit = 80;
        const float ChargeRateUpperLimit = 0.8f;

        const float TempWarningTolerance = TempUpperLimit * 0.05f;
        const float SocWarningTolerance = SocUpperLimit * 0.05f;
        const float ChargeRateWarningTolerance = ChargeRateUpperLimit * 0.05f;

        static bool CheckTemperature(float temperature)
        {
            bool status = true;
            if (IsOutOfRange(temperature, TempLowerLimit, TempUpperLimit))
            {
                Console.WriteLine("Temperature is out of range!");
                status = false;
            }
            else
            {
                PrintWarning(temperature, TempLowerLimit, TempUpperLimit, TempWarningTolerance, "Temperature");
            }
            return status;
        }

        static bool CheckSoc(float soc)
        {
            bool status = true;
            if (IsOutOfRange(soc, SocLowerLimit, SocUpperLimit))
            {
                Console.WriteLine("State of Charge is out of range!");
                status = false;
            }
            else
            {
                PrintWarning(soc, SocLowerLimit, SocUpperLimit, SocWarningTolerance, "State of Charge");
            }
            return status;
        }

        static bool CheckChargeRate(float chargeRate)
        {
            bool status = true;
            if (chargeRate > ChargeRateUpperLimit)
            {
                Console.WriteLine("Charge Rate is out of range!");
                status = false;
            }
            else if (chargeRate >= ChargeRateUpperLimit - ChargeRateWarningTolerance)
            {
                Console.WriteLine("Warning: Approaching charge-peak");
            }
            return status;
        }

        static bool IsOutOfRange(float value, float lowerLimit, float upperLimit)
        {
            return value < lowerLimit || value > upperLimit;
        }

        static void PrintWarning(float value, float lowerLimit, float upperLimit, float tolerance, string parameterName)
        {
            if (value <= lowerLimit + tolerance)
            {
                Console.WriteLine($"Warning: {parameterName} approaching discharge");
            }
            if (value >= upperLimit - tolerance)
            {
                Console.WriteLine($"Warning: {parameterName} approaching charge-peak");
            }
        }

        static bool batteryIsOk(float temperature, float soc, float chargeRate)
        {
            return CheckTemperature(temperature) && CheckSoc(soc) && CheckChargeRate(chargeRate);
        }

        static void ExpectTrue(bool expression)
        {
            if (!expression)
            {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
        }
        static void ExpectFalse(bool expression)
        {
            if (expression)
            {
                Console.WriteLine("Expected false, but got true");
                Environment.Exit(1);
            }
        }

        static int Main()
        {
            ExpectTrue(batteryIsOk(25, 70, 0.7f));
            ExpectFalse(batteryIsOk(50, 85, 0.0f));
            Console.WriteLine("All ok");
            return 0;
        }
    }
}
