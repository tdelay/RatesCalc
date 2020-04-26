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
            if (repository.List<Customer>().Count() >= 2) return;

            repository.Add(new Customer
            {
                PersonalId = 12345678,
                Name = "Goranas Truksevičius",
                HasAgreement = true,
            });

            repository.Add(new Customer
            {
                PersonalId = 78706196287,
                Name = "Dange Kulčiutė",
                HasAgreement = true,
            });

            repository.Add(new Agreement
            {
                CustomerId = 12345678,
                Amount = 12000,
                BaseRateCode = BaseRateCodeEnum.VILIBOR3m,
                Margin = 1.6,
                AgreementDuration = 60,
                AgreementShortDescription = "Family Loan Agreement"
            });

            repository.Add(new Agreement
            {
                CustomerId = 78706196287,
                Amount = 8000,
                BaseRateCode = BaseRateCodeEnum.VILIBOR1y,
                Margin = 2.2,
                AgreementDuration = 36,
                AgreementShortDescription = "Personal Loan Agreement"
            });

            repository.Add(new Agreement
            {
                CustomerId = 78706196287,
                Amount = 1000,
                BaseRateCode = BaseRateCodeEnum.VILIBOR6m,
                Margin = 1.85,
                AgreementDuration = 24,
                AgreementShortDescription = "Personal Loan Agreement"
            });
        }
    }
}
