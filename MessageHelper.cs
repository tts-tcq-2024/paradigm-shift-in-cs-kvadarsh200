namespace ParadigmShift
{
    public static class MessageHelper
    {
        private static string GetMessage(StatusType status, string warningMessage, string breachMessage)
        {
            switch (status)
            {
                case StatusType.Warning:
                    return warningMessage;
                case StatusType.Breach:
                    return breachMessage;
                default:
                    return "";
            }
        }

        public static string GetTemperatureMessage(StatusType status)
        {
            string warningMessage = GlobalSettings.AppLanguage == Language.English ? "Approaching temperature limit!" : "Annäherung an die Temperaturgrenze!";
            string breachMessage = GlobalSettings.AppLanguage == Language.English ? "Temperature is out of range!" : "Temperatur ist außerhalb des Bereichs!";

            return GetMessage(status, warningMessage, breachMessage);
        }

        public static string GetSocMessage(StatusType status)
        {
            string warningMessage = GlobalSettings.AppLanguage == Language.English ? "Approaching SOC limit!" : "Annäherung an die SOC-Grenze!";
            string breachMessage = GlobalSettings.AppLanguage == Language.English ? "State of Charge is out of range!" : "Ladezustand ist außerhalb des Bereichs!";

            return GetMessage(status, warningMessage, breachMessage);
        }

        public static string GetChargeRateMessage(StatusType status)
        {
            string warningMessage = GlobalSettings.AppLanguage == Language.English ? "Approaching charge rate limit!" : "Annäherung an die Ladegrenze!";
            string breachMessage = GlobalSettings.AppLanguage == Language.English ? "Charge Rate is out of range  

            return GetMessage(status, warningMessage, breachMessage);
        }
    }
}
