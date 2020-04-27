using RatesCalc.Core.Data;
using RatesCalc.Core.Enums;
using RatesCalc.Core.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.Web.Models
{
    public class AgreementDTO
    {
        public ICollection<BaseRateCodeEnum> AvailableCodeRates =
            Enum.GetValues(typeof(BaseRateCodeEnum)).Cast<BaseRateCodeEnum>().ToList();

        public int AgreementId { get; set; }
        public long CustomerId { get; set; }
        [Required]
        public double Margin { get; set; }
        [Required]
        public int AgreementDuration { get; set; }
        [Required]
        public double Amount { get; set; }
        public double CurrentRate { get; set; }

        [Required]
        public BaseRateCodeEnum BaseRateCode { get; set; }
        public BaseRateCodeEnum NewBaseRateCode { get; set; }

        public static AgreementDTO FromAgreement(Agreement agreement) => new AgreementDTO
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
