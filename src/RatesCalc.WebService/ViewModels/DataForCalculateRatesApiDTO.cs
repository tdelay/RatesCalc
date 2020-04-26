using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.WebService.ViewModels
{
    public class DataForCalculateRatesApiDTO
    {
        public int AgreementId { get; set; }
        public string BaseRateCode { get; set; }
    }
}
