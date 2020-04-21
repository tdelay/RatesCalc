using RatesCalc.SharedBase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalc.Core.Data
{
    public class Agreement : BaseEntity
    {
        public long CustomerId { get; set; }
        public double Amount { get; set; }
        public string BaseRateCode { get; set; }
        public double Margin { get; set; }
        public int AgreementDuration { get; set; }
        public string AgreementShortDescription { get; set; }
        public Customer Customer { get; set; }

    }
}
