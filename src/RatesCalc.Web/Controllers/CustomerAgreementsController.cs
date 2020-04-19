using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RatesCalc.Web.Controllers
{
    public class CustomerAgreementsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}