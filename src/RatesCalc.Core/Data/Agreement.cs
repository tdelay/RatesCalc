using RatesCalc.Core.Enums;
using RatesCalc.SharedBase.Entities;

namespace RatesCalc.Core.Data
{
    public class Agreement : BaseEntity
    {
        public int AgreementId { get; set; }
        public long CustomerId { get; set; }
        public double Amount { get; set; }
        public double Margin { get; set; }
        public int AgreementDuration { get; set; }
        public string AgreementShortDescription { get; set; }
        public BaseRateCodeEnum BaseRateCode { get; set; }
        public double CurrentRate { get; set; }
        public Customer Customer { get; set; }
       

    }
}
