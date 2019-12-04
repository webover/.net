using System;
using System.Threading;

namespace Timer
{
    class Timer
    {
        public delegate void TimeDelegate(int interval);

        private int interval = 0;
        public Timer(int interval)
        {
            this.interval = interval;
        }

        public static void Message(int interval)
        {
            Console.WriteLine($"Time now is {{0:HH:mm:ss}}", DateTime.Now);

            Thread.Sleep(interval * 1000);
        }
    }
}
