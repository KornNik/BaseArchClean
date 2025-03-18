using System;

namespace Behaviours
{
    sealed class TimeStempPorvidor : ITimestampProvider
    {
        public long Provide() => DateTime.UtcNow.Ticks;
    }
}
