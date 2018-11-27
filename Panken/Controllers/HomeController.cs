using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Panken.Models;
using Panken.Repo;
using Panken.ViewModels;

namespace Panken.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = BankRepository.GetCustomers();
            return View(model);
        }
        public IActionResult DepositWithraw()
        {
            return View();
        }
        public IActionResult ProcessForm(DepositWithrawVM form, string deposit, string withraw)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(deposit))
                {
                    if (Bank.Deposit(form))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error! We couldn't find the account.");

                    }
                }
                if (!string.IsNullOrEmpty(withraw))
                {
                    if (Bank.AccountExists(form.AccountNumber))
                    {
                        if (Bank.Withraw(form))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Error! Insufficient funds.");

                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error! We couldn't find the account.");
                    }
                }
            }


            return View("DepositWithraw");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
