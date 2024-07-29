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
            if (temperature < TempLowerLimit || temperature > TempUpperLimit)
            {
                Console.WriteLine("Temperature is out of range!");
                status = false;
            }
            else
            {
                if (temperature <= TempLowerLimit + TempWarningTolerance)
                {
                    Console.WriteLine("Warning: Approaching discharge");
                }
                if (temperature >= TempUpperLimit - TempWarningTolerance)
                {
                    Console.WriteLine("Warning: Approaching charge-peak");
                }
            }
            return status;
        }

        static bool CheckSoc(float soc)
        {
            bool status = true;
            if (soc < SocLowerLimit || soc > SocUpperLimit)
            {
                Console.WriteLine("State of Charge is out of range!");
                status = false;
            }
            else
            {
                if (soc <= SocLowerLimit + SocWarningTolerance)
                {
                    Console.WriteLine("Warning: Approaching discharge");
                }
                if (soc >= SocUpperLimit - SocWarningTolerance)
                {
                    Console.WriteLine("Warning: Approaching charge-peak");
                }
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
            else
            {
                if (chargeRate >= ChargeRateUpperLimit - ChargeRateWarningTolerance)
                {
                    Console.WriteLine("Warning: Approaching charge-peak");
                }
            }
            return status;
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
