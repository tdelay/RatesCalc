using RatesCalc.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.Web.Models
{
    public class AgreementDTO
    {
        public long CustomerId { get; set; }
        public string BaseRateCode { get; set; }
        public double Margin { get; set; }
        public int AgreementDuration { get; set; }
        public double Amount { get; set; }

        public static AgreementDTO FromAgreement(Agreement agreement) => new AgreementDTO
        {
            CustomerId = agreement.CustomerId,
            BaseRateCode = agreement.BaseRateCode,
            Margin = agreement.Margin,
            AgreementDuration = agreement.AgreementDuration,
            Amount = agreement.Amount
        };
    }
}
