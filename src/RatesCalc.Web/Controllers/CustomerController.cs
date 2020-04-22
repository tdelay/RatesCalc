using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RatesCalc.Core.Data;
using RatesCalc.Core.Helpers;
using RatesCalc.SharedBase.Interfaces;
using RatesCalc.Web.Models;

namespace RatesCalc.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IRepository _repository;

        public CustomerController(IRepository repository, ILogger<CustomerController> logger)
        {
            _logger = logger;
            _repository = repository;
            this.SeedData();
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
        public IActionResult Index()
        {
            var items = _repository.List<Customer>()
                           .Select(CustomerDTO.FromCustomer);
            return View(items);

        }

        /// <summary>
        /// Customer Details
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Customer instance with added Agreements List</returns>
        public IActionResult Details(int id)
        {
            var customer = new CustomerDTO();
            try
            {
                _logger.LogInformation("Trying to get Customers instance with Agreements list");
                customer = CustomerDTO.FromCustomer(_repository.GetById<Customer>(id));
                customer.Agreements = _repository.List<Agreement>()
                                        .Where(a => a.CustomerId == customer.PersonalId)
                                        .Select(AgreementDTO.FromAgreement)
                                        .ToList();

                return View(customer);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View(customer);
            }

        }
    }
}