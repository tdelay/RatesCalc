using RatesCalc.SharedBase.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RatesCalc.Core.Data
{
    public class Agreement : BaseEntity
    {
        private static readonly ICollection<string> AvailableCodeRates =
            new ReadOnlyCollection<string>(new string[] { "VILIBOR1m", "VILIBOR3m", "VILIBOR6m", "VILIBOR1y" });

        private string _BaseRateCode;
        public long CustomerId { get; set; }
        public double Amount { get; set; }
        public double Margin { get; set; }
        public int AgreementDuration { get; set; }
        public string AgreementShortDescription { get; set; }
        public Customer Customer { get; set; }
        public string BaseRateCode
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

    }
}
