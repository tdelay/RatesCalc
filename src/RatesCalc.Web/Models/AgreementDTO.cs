using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.Web.Models
{
    public class AgreementDTO
    {
        public int CustomerId { get; set; }
        public string BaseRateCode { get; set; }
        public decimal Margin { get; set; }
        public int AgreementDuration { get; set; }
    }
}
