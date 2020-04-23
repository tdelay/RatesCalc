using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RatesCalc.Core.Enums
{
    public enum BaseRateCodeEnum
    {
        [Display(Name = "VILIBOR1m")]
        VILIBOR1m,
        [Display(Name = "VILIBOR3m")]
        VILIBOR3m,
        [Display(Name = "VILIBOR6m")]
        VILIBOR6m,
        [Display(Name = "VILIBOR1y")]
        VILIBOR1y
    }
}
