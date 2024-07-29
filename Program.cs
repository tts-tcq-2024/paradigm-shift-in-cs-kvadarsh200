using System;

namespace ParadigmShift
{
    class Program
    {
        // Check if the expression is true, otherwise throw an error
        static void ExpectTrue(bool expression)
        {
            if (!expression)
            {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
        }

        // Check if the expression is false, otherwise throw an error
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
            // Setting language to English for these tests
            GlobalSettings.AppLanguage = Language.English;
            
            // Test cases in English
            ExpectTrue(Checker.BatteryIsOk(25, 70, 0.7f));
            ExpectFalse(Checker.BatteryIsOk(50, 85, 0.0f));

            // Setting language to German for these tests
            GlobalSettings.AppLanguage = Language.German;
            
            // Test cases in German
            ExpectTrue(Checker.BatteryIsOk(25, 70, 0.7f));
            ExpectFalse(Checker.BatteryIsOk(50, 85, 0.0f));

            Console.WriteLine("All tests passed.");
            return 0;
        }
    }
}
