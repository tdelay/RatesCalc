using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RatesCalc.Core.Data;
using RatesCalc.SharedBase.Interfaces;
using RatesCalc.Web.Models;

namespace RatesCalc.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IRepository _repository;

        public CustomerController(ILogger<CustomerController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
            try
            {
                DbSeeder.SeedDBCustomers(_repository);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
            }
        }

        public IActionResult Index()
        {
            var items = _repository.List<Customer>()
                           .Select(CustomerDTO.FromCustomer);
            return View(items);

        }
    }
}