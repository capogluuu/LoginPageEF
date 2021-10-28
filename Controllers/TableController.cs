using Microsoft.AspNetCore.Mvc;
using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginPage.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            Console.WriteLine("Buraya Geldi");
            return View();
        }

        /*public IActionResult Index(Login login)
        {
            return View();
        }*/
    }
}
