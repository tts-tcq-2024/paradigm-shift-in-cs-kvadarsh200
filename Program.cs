using System;

namespace paradigm_shift_csharp
{
    class Program
    {
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
            var logger = new TestWarningLogger();
            var checker = new Checker(logger);

            ExpectTrue(checker.BatteryIsOk(25, 70, 0.7f));
            ExpectFalse(checker.BatteryIsOk(50, 85, 0.0f));
            Console.WriteLine("All ok");
            return 0;
        }
    }
}
