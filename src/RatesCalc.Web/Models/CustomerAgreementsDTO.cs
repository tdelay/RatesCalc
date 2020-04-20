using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.Web.Models
{
    public class CustomerAgreementsDTO
    {
        public CustomerDTO Customer { get; set; }
        public AgreementDTO Agreement { get; set; }

    }
}
