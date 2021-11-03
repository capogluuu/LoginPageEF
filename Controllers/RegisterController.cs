using LoginPage.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;

namespace LoginPage.Controllers
{
    public class RegisterController : Controller
    {
        private readonly TableContext _context;
        public RegisterController(TableContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, string surname, string gsm, string address, string username,
            string password, string re_password, string status)
        {
            //bool dublicated = false;
            char[] charsToTrim = { ' ' };
            username = username.Trim(charsToTrim);
            if (password == re_password)
            {
                // to do -> check dublicate situation
                // to do -> give an alert for duplicate cases

                var cs = "Host=localhost;Port=5432;User Id=postgres;Password=test;Database=EfLoginPage;";
                using var con = new NpgsqlConnection(cs);
                con.Open();

                string query = "select COUNT(*) from public.\"Logins\"" + $" WHERE username='{username}'";

                using var cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;

                ViewBag.Message = "true";
                if ((Int64)cmd.ExecuteScalar() > 0)
                {
                    ViewBag.Message = "false";
                    return View("~/Views/Register/Index.cshtml");
                }

                cmd.CommandText = $"INSERT INTO public.\"Logins\" (username, name, surname, gsm, adress,  password, status)" +
                    $" VALUES('{username}','{name}','{surname}','{gsm}','{address}','{password}','{status}')";
                //cmd.ExecuteNonQuery();


                //var list = _context.Logins.ToList();
                //return Redirect("~/Views/Table/Index.cshtml",list);

                return View("~/Views/Table/Router.cshtml");
                //return View("~/Views/Table/Index.cshtml");

            }

            else
            {
                return View("~/Views/Register/Index.cshtml");
                //return View("~/Views/Table/Index.cshtml");

            }
        }
    }
}
