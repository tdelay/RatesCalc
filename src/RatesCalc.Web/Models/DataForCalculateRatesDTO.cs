using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.Web.Models
{
    public class DataForCalculateRatesDTO
    {
        public int AgreementId { get; set; }
        public string BaseRateCode { get; set; }
    }
}
