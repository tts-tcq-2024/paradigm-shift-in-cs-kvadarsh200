namespace ParadigmShift
{
    public static class MessageHelper
    {
        public static string GetTemperatureMessage(StatusType status)
        {
            switch (status)
            {
                case StatusType.Warning:
                    return GlobalSettings.AppLanguage == Language.English ? "Approaching temperature limit!" : "Annäherung an die Temperaturgrenze!";
                case StatusType.Breach:
                    return GlobalSettings.AppLanguage == Language.English ? "Temperature is out of range!" : "Temperatur ist außerhalb des Bereichs!";
                default:
                    return "";
            }
        }

        public static string GetSocMessage(StatusType status)
        {
            switch (status)
            {
                case StatusType.Warning:
                    return GlobalSettings.AppLanguage == Language.English ? "Approaching SOC limit!" : "Annäherung an die SOC-Grenze!";
                case StatusType.Breach:
                    return GlobalSettings.AppLanguage == Language.English ? "State of Charge is out of range!" : "Ladezustand ist außerhalb des Bereichs!";
                default:
                    return "";
            }
        }

        public static string GetChargeRateMessage(StatusType status)
        {
            switch (status)
            {
                case StatusType.Warning:
                    return GlobalSettings.AppLanguage == Language.English ? "Approaching charge rate limit!" : "Annäherung an die Ladegrenze!";
                case StatusType.Breach:
                    return GlobalSettings.AppLanguage == Language.English ? "Charge Rate is out of range!" : "Laderate ist außerhalb des Bereichs!";
                default:
                    return "";
            }
        }
    }
}

