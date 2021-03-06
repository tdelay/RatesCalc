﻿using RatesCalc.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.WebService.ViewModels
{
    public class CustomerApiDTO
    {
        public int CustomerId { get; set; }
        public long PersonalId { get; set; }
        public string Name { get; set; }
        public ICollection<AgreementApiDTO> Agreements { get; set; }
        // TODO: use AutoMappper 
        public static CustomerApiDTO FromCustomer(Customer customer) => new CustomerApiDTO
        {
            CustomerId = customer.CustomerId,
            PersonalId = customer.PersonalId,
            Name = customer.Name,
        };
    }
}
