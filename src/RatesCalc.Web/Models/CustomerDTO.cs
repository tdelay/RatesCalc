using RatesCalc.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.Web.Models
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public long PersonalId { get; set; }
        public string Name { get; set; }
        public ICollection<AgreementDTO> Agreements { get; set; }
        // TODO: use AutoMappper 
        public static CustomerDTO FromCustomer(Customer customer) => new CustomerDTO
        {
            CustomerId = customer.CustomerId,
            PersonalId = customer.PersonalId,
            Name = customer.Name,
        };

    }
}
