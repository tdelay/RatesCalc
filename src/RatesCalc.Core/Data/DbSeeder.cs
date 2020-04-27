using RatesCalc.Core.Enums;
using RatesCalc.SharedBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatesCalc.Core.Data
{
    public class DbSeeder
    {
        public static void SeedDBCustomers(IRepository repository)
        {
            var customers = repository.List<Customer>().ToList();
            if (customers.Count() >= 2) return;

            repository.Add(new Customer
            {
                CustomerId = 1,
                PersonalId = 12345678,
                Name = "Goranas Truksevičius",
                HasAgreement = true,
            });

            repository.Add(new Customer
            {
                CustomerId = 2,
                PersonalId = 78706196287,
                Name = "Dange Kulčiutė",
                HasAgreement = true,
            });

            repository.Add(new Agreement
            {
                CustomerId = 1,
                AgreementId = 1,
                Amount = 12000,
                BaseRateCode = BaseRateCodeEnum.VILIBOR3m,
                Margin = 1.6,
                AgreementDuration = 60,
                AgreementShortDescription = "Family Loan Agreement"
            });

            repository.Add(new Agreement
            {
                CustomerId = 2,
                Amount = 8000,
                AgreementId = 2,
                BaseRateCode = BaseRateCodeEnum.VILIBOR1y,
                Margin = 2.2,
                AgreementDuration = 36,
                AgreementShortDescription = "Personal Loan Agreement"
            });

            repository.Add(new Agreement
            {
                CustomerId = 2,
                AgreementId = 3,
                Amount = 1000,
                BaseRateCode = BaseRateCodeEnum.VILIBOR6m,
                Margin = 1.85,
                AgreementDuration = 24,
                AgreementShortDescription = "Personal Loan Agreement"
            });
        }
    }
}
