using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloMvc.Models;

namespace HelloMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //call view() which searches for a view with same name as current action method
            return View();
        }

        public IActionResult Privacy()
        {
            //return View();
            Customer customer = new Customer();
            return View(customer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
