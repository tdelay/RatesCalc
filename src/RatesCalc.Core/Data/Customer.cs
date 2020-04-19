using RatesCalc.Core.Events;
using RatesCalc.SharedBase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalc.Core.Data
{
    public class Customer : BaseEntity
    {
        public int PersonalId { get; set; }
        public string Name { get; set; }
        public bool HasAgreement { get; set; } = false;

        public void SignAgreement()
        {
            HasAgreement = true;
            Events.Add(new CustomerSignAgreementEvent(this));
        }
    }
}
