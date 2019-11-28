using System;

namespace CarStore
{
    class ConsoleLogger : LogBase
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
