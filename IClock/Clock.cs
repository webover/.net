using System;

namespace IClock
{
    public class Clock : IClock
    {
        public DateTime Now => DateTime.Now;

        public DateTime UtcNow => DateTime.UtcNow;

        public BusinessDate Today => new BusinessDate(DateTime.Now);

    }
}
