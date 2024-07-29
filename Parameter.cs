namespace paradigm_shift_csharp
{
    public class Parameter
    {
        private readonly string name;
        private readonly float lowerLimit;
        private readonly float upperLimit;
        private readonly float warningTolerance;
        private readonly BatteryStatus batteryStatus;

        public Parameter(string name, float lowerLimit, float upperLimit, float warningTolerance, BatteryStatus batteryStatus)
        {
            this.name = name;
            this.lowerLimit = lowerLimit;
            this.upperLimit = upperLimit;
            this.warningTolerance = warningTolerance;
            this.batteryStatus = batteryStatus;
        }

        public bool Check(float value)
        {
            if (value < lowerLimit || value > upperLimit)
            {
                batteryStatus.AddMessage(Localization.GetMessage($"{name}_BREACH"));
                return false;
            }
            else if (value < lowerLimit + warningTolerance)
            {
                batteryStatus.AddMessage(Localization.GetMessage($"{name}_APPROACHING_DISCHARGE"));
            }
            else if (value > upperLimit - warningTolerance)
            {
                batteryStatus.AddMessage(Localization.GetMessage($"{name}_APPROACHING_PEAK"));
            }

            return true;
        }
    }
}
