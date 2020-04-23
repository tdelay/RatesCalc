using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.Web.Models
{
    public class CalculatedInterestDTO
    {
        public double ExistingInteresRate { get; set; }
        public double CalculatedInteresRate { get; set; } = -1;
    }
}
