using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.WebService.ViewModels
{
    public class CalculatedInterestApiDTO
    {
        public double ExistingInteresRate { get; set; }
        public double CalculatedInteresRate { get; set; } = -1;
        public double DifferenceInteresRate { get; set; }
    }
}
