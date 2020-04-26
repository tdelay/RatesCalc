using RatesCalc.Core.Data;
using RatesCalc.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.WebAPI.ViewModels
{
    public class AgreementDTO
    {
        public int Id { get; set; }
        public long CustomerId { get; set; }
        public double Margin { get; set; }
        public int AgreementDuration { get; set; }
        public double Amount { get; set; }
        public double CurrentRate { get; set; }
        public BaseRateCodeEnum BaseRateCode { get; set; }
        public BaseRateCodeEnum NewBaseRateCode { get; set; }

        public static AgreementDTO FromAgreement(Agreement agreement) => new AgreementDTO
        {
            Id = agreement.Id,
            CustomerId = agreement.CustomerId,
            BaseRateCode = agreement.BaseRateCode,
            Margin = agreement.Margin,
            AgreementDuration = agreement.AgreementDuration,
            Amount = agreement.Amount
        };
    }
}
