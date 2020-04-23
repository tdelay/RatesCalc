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
        public static readonly ICollection<BaseRateCodeEnum> AvailableCodeRates =
            Enum.GetValues(typeof(BaseRateCodeEnum)).Cast<BaseRateCodeEnum>().ToList();

        private BaseRateCodeEnum _BaseRateCode;

        public long CustomerId { get; set; }
        [Required]
        public double Margin { get; set; }
        [Required]
        public int AgreementDuration { get; set; }
        [Required]
        public double Amount { get; set; }
        public double CurrentRate { get; set; }

   
        [Required]
        public BaseRateCodeEnum BaseRateCode
        {
            get
            {
                return _BaseRateCode;
            }
            set
            {
                if (AvailableCodeRates.Contains(value))
                {
                    _BaseRateCode = value;
                }
                else
                {
                    throw (new ArgumentOutOfRangeException("BaseRateCode", value, string.Format("Base Rate code must be one of: {0}", string.Join(", ", AvailableCodeRates))));
                }
            }
        }

        public static AgreementDTO FromAgreement(Agreement agreement) => new AgreementDTO
        {
            CustomerId = agreement.CustomerId,
            BaseRateCode = agreement.BaseRateCode,
            Margin = agreement.Margin,
            AgreementDuration = agreement.AgreementDuration,
            Amount = agreement.Amount

        };

        public async Task<double> GetInterestRateValue()
        {
            CurrentRate = await BaseRateValueApiFactory.Instance.GetRates(BaseRateCode.ToString());
            return CurrentRate + Margin;
        }

    }
}
