using RatesCalc.Core.Events;
using RatesCalc.SharedBase.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RatesCalc.Core.Data
{
    public class Customer : BaseEntity
    {
        public long PersonalId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public bool HasAgreement { get; set; } = false;
        public ICollection<Agreement> Agreements { get; set; }

        public void SignAgreement()
        {
            HasAgreement = true;
            Events.Add(new CustomerSignAgreementEvent(this));
        }
    }
}
