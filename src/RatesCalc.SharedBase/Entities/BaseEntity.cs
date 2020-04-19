using RatesCalc.SharedBase.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalc.SharedBase.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
