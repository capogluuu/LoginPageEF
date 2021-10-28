using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;

namespace LoginPage.Controllers
{
    public class RegisterController : Controller
    {
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

                var cs = "Host=localhost;Port=5432;User Id=postgres;Password=Akif3mre.;Database=Personnal_database;";
                using var con = new NpgsqlConnection(cs);
                con.Open();

                string query = "select COUNT(*) from public.registration" + $" WHERE username='{username}'";

                using var cmd = new NpgsqlCommand();
                cmd.Connection = con;

                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS registration (
                                    Name varchar(45) NOT NULL,
                                    Surname varchar(45) NOT NULL,
                                    GSM varchar(45) NOT NULL,
                                    Address varchar(45) NOT NULL,
                                    Username varchar(45) NOT NULL,
                                    Password varchar(450) NOT NULL,
                                    Status varchar(45) NOT NULL,
                                    PRIMARY KEY (Username))";
                cmd.ExecuteNonQuery();

                cmd.CommandText = query;

                ViewBag.Message = "true";
                if ((Int64)cmd.ExecuteScalar() > 0)
                {
                    ViewBag.Message = "false";
                    return View("~/Views/Register/Index.cshtml");
                }

                cmd.CommandText = $"INSERT INTO registration(name, surname, gsm, address, username, password, status)" +
                    $" VALUES('{name}','{surname}','{gsm}','{address}','{username}','{password}','{status}')";
                cmd.ExecuteNonQuery();
                return View("~/Views/Table/Index.cshtml");
            }

            else
            {
                return View("~/Views/Register/Index.cshtml");
                //return View("~/Views/Table/Index.cshtml");

            }
        }
    }
}
