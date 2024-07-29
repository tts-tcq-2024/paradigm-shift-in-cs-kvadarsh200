using System.Collections.Generic;

namespace paradigm_shift_csharp
{
    static class Localization
    {
        private static string language = "EN";
        private static readonly Dictionary<string, Dictionary<string, string>> messages = new Dictionary<string, Dictionary<string, string>>
        {
            { "EN", new Dictionary<string, string> {
                { "Temperature_BREACH", "Temperature is out of range!" },
                { "Temperature_APPROACHING_DISCHARGE", "Warning: Approaching discharge" },
                { "Temperature_APPROACHING_PEAK", "Warning: Approaching charge-peak" },
                { "SoC_BREACH", "State of Charge is out of range!" },
                { "SoC_APPROACHING_DISCHARGE", "Warning: Approaching discharge" },
                { "SoC_APPROACHING_PEAK", "Warning: Approaching charge-peak" },
                { "Charge Rate_BREACH", "Charge Rate is out of range!" },
                { "Charge Rate_APPROACHING_DISCHARGE", "Warning: Approaching discharge" },
                { "Charge Rate_APPROACHING_PEAK", "Warning: Approaching charge-peak" }
            }},
            { "DE", new Dictionary<string, string> {
                { "Temperature_BREACH", "Die Temperatur ist außerhalb des zulässigen Bereichs!" },
                { "Temperature_APPROACHING_DISCHARGE", "Warnung: Annäherung an die Entladung" },
                { "Temperature_APPROACHING_PEAK", "Warnung: Annäherung an die Lade-Spitze" },
                { "SoC_BREACH", "Ladezustand ist außerhalb des zulässigen Bereichs!" },
                { "SoC_APPROACHING_DISCHARGE", "Warnung: Annäherung an die Entladung" },
                { "SoC_APPROACHING_PEAK", "Warnung: Annäherung an die Lade-Spitze" },
                { "Charge Rate_BREACH", "Laderate ist außerhalb des zulässigen Bereichs!" },
                { "Charge Rate_APPROACHING_DISCHARGE", "Warnung: Annäherung an die Entladung" },
                { "Charge Rate_APPROACHING_PEAK", "Warnung: Annäherung an die Lade-Spitze" }
            }}
        };

        public static void SetLanguage(string lang)
        {
            language = lang;
        }

        public static string GetMessage(string key)
        {
            return messages[language][key];
        }
    }
}
