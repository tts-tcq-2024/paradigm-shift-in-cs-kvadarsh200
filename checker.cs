using System;

namespace ParadigmShift
{
    public class checker
    {
        private readonly List<Parameter> parameters = new List<Parameter>();

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
