using RatesCalc.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.Web.Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public long PersonalId { get; set; }
        public string Name { get; set; }

        public List<AgreementDTO> agreements = new List<AgreementDTO>();
        // TODO: use Automapper
        public static CustomerDTO FromCustomer(Customer customer) => new CustomerDTO
        {
            Id = customer.Id,
            PersonalId = customer.PersonalId,
            Name = customer.Name
        };

    }
}
