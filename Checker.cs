using System.Collections.Generic;

namespace paradigm_shift_csharp
{
    class Checker
    {
        private List<Parameter> parameters = new List<Parameter>();

        public void AddParameter(Parameter parameter)
        {
            parameters.Add(parameter);
        }

        public bool CheckBattery(params float[] values)
        {
            bool isBatteryOk = true;

            for (int i = 0; i < values.Length; i++)
            {
                isBatteryOk &= parameters[i].Check(values[i]);
            }

            return isBatteryOk;
        }
    }
}
