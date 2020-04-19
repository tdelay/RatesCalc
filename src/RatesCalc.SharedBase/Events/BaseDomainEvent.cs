using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalc.SharedBase.Events
{
    public class BaseDomainEvent
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
