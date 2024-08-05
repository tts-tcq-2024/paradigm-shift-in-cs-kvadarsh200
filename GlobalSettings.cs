namespace ParadigmShift
{
    public enum Language
    {
        English,
        German
    }

    public static class GlobalSettings
    {
        public static Language AppLanguage = Language.English;
        public const float WarningTolerance = 0.05f;
    }
}
