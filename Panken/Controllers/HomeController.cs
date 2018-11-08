using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Panken.Models;
using Panken.Repo;

namespace Panken.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = BankRepository.GetCustomers();
            return View(model);
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
