using System;

namespace paradigm_shift_csharp
{
    class Checker
    {
        static bool CheckTemperature(float temperature, out string message)
        {
            if (temperature < 0 || temperature > 45)
            {
                message = temperature < 0 ? "Temperature is too low!" : "Temperature is too high!";
                return false;
            }
            message = "Temperature is within range.";
            return true;
        }

        static bool CheckSoc(float soc, out string message)
        {
            if (soc < 20 || soc > 80)
            {
                message = soc < 20 ? "State of Charge is too low!" : "State of Charge is too high!";
                return false;
            }
            message = "State of Charge is within range.";
            return true;
        }

        static bool CheckChargeRate(float chargeRate, out string message)
        {
            if (chargeRate > 0.8)
            {
                message = "Charge Rate is too high!";
                return false;
            }
            message = "Charge Rate is within range.";
            return true;
        }

        static bool BatteryIsOk(float temperature, float soc, float chargeRate, out string message)
        {
            if (!CheckTemperature(temperature, out string tempMsg) ||
                !CheckSoc(soc, out string socMsg) ||
                !CheckChargeRate(chargeRate, out string chargeRateMsg))
            {
                message = tempMsg + ", " + socMsg + ", " + chargeRateMsg;
                return false;
            }
            message = "Battery is OK.";
            return true;
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

        static void RunTests()
        {
            string message;
            ExpectTrue(BatteryIsOk(25, 70, 0.7f, out message));
            Console.WriteLine(message);
            ExpectFalse(BatteryIsOk(50, 85, 0.0f, out message));
            Console.WriteLine(message);
            ExpectFalse(BatteryIsOk(-5, 50, 0.5f, out message));
            Console.WriteLine(message);
            ExpectFalse(BatteryIsOk(25, 85, 0.5f, out message));
            Console.WriteLine(message);
            ExpectFalse(BatteryIsOk(25, 50, 0.9f, out message));
            Console.WriteLine(message);
        }

        static int Main()
        {
            RunTests();
            Console.WriteLine("All ok");
            return 0;
        }
    }
}
