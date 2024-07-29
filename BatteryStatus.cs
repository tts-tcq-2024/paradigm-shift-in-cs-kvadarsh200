namespace ParadigmShift
{
    public class BatteryStatus
    {
        private readonly List<string> messages = new List<string>();

        public void AddMessage(string message)
        {
            messages.Add(message);
        }

        public void PrintMessages()
        {
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}