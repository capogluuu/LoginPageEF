using Microsoft.AspNetCore.Mvc;
using LoginPage.Models;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoginPage.Controllers
{
    public class LoginController : Controller
    {
        public IConfiguration configuration;

        private readonly TableContext _context;
        public LoginController(IConfiguration iConfig, TableContext context)
        {
            configuration = iConfig;
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {

            char[] charsToTrim = { ' ' };

            Table table;
            if (username != null && password != null)
            {
                table = _context.Tables.Find(username);
                if (table.password == password)
                {
                    return View("~/Views/Table/Router.cshtml");
                }
            }
            else
            {
                return View();
            }
            return View("~/Views/Shared/Error.cshtml");

            
        }
    }
}
