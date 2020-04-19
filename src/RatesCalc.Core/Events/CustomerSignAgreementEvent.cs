using RatesCalc.Core.Data;
using RatesCalc.SharedBase.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalc.Core.Events
{
    class CustomerSignAgreementEvent : BaseDomainEvent
    {
        public Customer Customer { get; set; }
        public CustomerSignAgreementEvent(Customer customer)
        {
            Customer = customer;
        }
    }
}
