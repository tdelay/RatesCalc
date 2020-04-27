using RatesCalc.Core.Data;
using RatesCalc.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.WebService.ViewModels
{
    public class AgreementApiDTO
    {
        public int AgreementId { get; set; }
        public long CustomerId { get; set; }
        public double Margin { get; set; }
        public int AgreementDuration { get; set; }
        public double Amount { get; set; }
        public double CurrentRate { get; set; }
        public BaseRateCodeEnum BaseRateCode { get; set; }
        public BaseRateCodeEnum NewBaseRateCode { get; set; }

        public static AgreementApiDTO FromAgreement(Agreement agreement) => new AgreementApiDTO
        {
            AgreementId = agreement.AgreementId,
            CustomerId = agreement.CustomerId,
            BaseRateCode = agreement.BaseRateCode,
            Margin = agreement.Margin,
            AgreementDuration = agreement.AgreementDuration,
            Amount = agreement.Amount
        };
    }
}
