using RatesCalc.SharedBase.Events;
using RatesCalc.SharedBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RatesCalc.Infrastructure.DomainEvents
{
   public class DomainEventDispatcher : IDomainEventDispatcher
    {
        public Task Dispatch(BaseDomainEvent domainEvent)
        {
            // Do nothing
            return Task.CompletedTask;
        }
    }
}
