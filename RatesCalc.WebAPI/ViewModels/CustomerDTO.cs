using RatesCalc.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.WebAPI.ViewModels
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public long PersonalId { get; set; }
        public string Name { get; set; }
        public ICollection<AgreementDTO> Agreements { get; set; }
        // TODO: use AutoMappper 
        public static CustomerDTO FromCustomer(Customer customer) => new CustomerDTO
        {
            Id = customer.Id,
            PersonalId = customer.PersonalId,
            Name = customer.Name,
        };

    }
}
