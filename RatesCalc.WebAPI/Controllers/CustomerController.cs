using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using RatesCalc.Core.Data;
using RatesCalc.Core.Factories;
using RatesCalc.Infrastructure.Data;
using RatesCalc.SharedBase.Interfaces;
using RatesCalc.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesCalc.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomerController : BaseApiController
    {
        private readonly IRepository _repository;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IRepository repository, ILogger<CustomerController> logger)
        {
            _logger = logger;
            _repository = repository;
            SeedData();
        }

        /// <summary>
        /// Seed Data Base with mock data
        /// </summary>
        private void SeedData()
        {
            try
            {
                DbSeeder.SeedDBCustomers(_repository);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Customers
        /// </summary>
        /// <returns>List of Customers</returns>
        [Route("~/api/GetAllCustomers")]
        [HttpGet]
        public IEnumerable<CustomerDTO> Get()
        {
            var customers = _repository.List<Customer>().Select(CustomerDTO.FromCustomer).ToList();
            customers.ForEach(c => c.Agreements = _repository.List<Agreement>()
                                                    .Where(a => a.CustomerId == c.PersonalId)
                                                    .Select(AgreementDTO.FromAgreement).ToList());
            return customers;
          
        }


        [Route("~/api/CalculateInterestRate")]
        [HttpPost]
        public async Task<CalculatedInterestDTO> CalculateInterestRate([FromBody] DataForCalculateRatesDTO obj)
        {
            var agreemenet = _repository.GetById<Agreement>(obj.AgreementId);

            var existingInteresRate = await BaseRateValueApiFactory.Instance.GetRates(agreemenet.BaseRateCode.ToString());
            var calculatedInteresRate = await BaseRateValueApiFactory.Instance.GetRates(obj.BaseRateCode);
            return new CalculatedInterestDTO
            {
                ExistingInteresRate = existingInteresRate,
                CalculatedInteresRate = calculatedInteresRate,
                DifferenceInteresRate = existingInteresRate - calculatedInteresRate
            };
        }  
        
    }
}
