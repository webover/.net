using System;

namespace IClock
{
    interface IClock
    {
        DateTime Now { get; }

        DateTime UtcNow { get; }

        BusinessDate Today { get; }
    }
}
