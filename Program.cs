using System;

namespace paradigm_shift_csharp
{
    class Program
    {
        static int Main()
        {
            // Set the language to German for this example
            Localization.SetLanguage("DE");

            BatteryStatus batteryStatus = new BatteryStatus();

            Checker checker = new Checker();
            checker.AddParameter(new Parameter("Temperature", 0, 45, 5, batteryStatus));
            checker.AddParameter(new Parameter("SoC", 20, 80, 5, batteryStatus));
            checker.AddParameter(new Parameter("Charge Rate", 0, 0.8f, 5, batteryStatus));

            ExpectTrue(checker.CheckBattery(25, 70, 0.7f));
            ExpectFalse(checker.CheckBattery(50, 85, 0.9f));

            batteryStatus.PrintMessages();

            Console.WriteLine("All ok");
            return 0;
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
    }
}
