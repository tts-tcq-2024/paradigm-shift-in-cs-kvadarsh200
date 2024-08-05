using System;
namespace paradigm_shift_csharp
{
     class Checker
    {
        private readonly RangeChecker _rangeChecker;
        private readonly Notifier _notifier;
        
        public Checker()
        {
            _rangeChecker = new RangeChecker();
            _notifier = new Notifier();
        }

        public bool BatteryIsOk(float temperature, float soc, float chargeRate)
        {
            return _rangeChecker.Check(temperature, Constants.TempLowerLimit, Constants.TempUpperLimit, "Temperature") &&
                   _rangeChecker.Check(soc, Constants.SocLowerLimit, Constants.SocUpperLimit, "State of Charge") &&
                   _rangeChecker.CheckChargeRate(chargeRate);
        }
    }
}
