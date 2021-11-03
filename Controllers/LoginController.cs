using Microsoft.AspNetCore.Mvc;
using LoginPage.Models;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

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
            // to do -> create an index file to send model type data to website
            // to do login page düzenlenecek
            char[] charsToTrim = { ' ' };


            var cs = "Host=localhost;Port=5432;User Id=postgres;Password=test;Database=EfLoginPage;";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string query = "select COUNT(*) from public.\"Tables\" " + $" WHERE username='{username}' and password='{password}'";

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;

            if ((Int64)cmd.ExecuteScalar() > 0)
            {
                query = $"SELECT * FROM public.\"Tables\"  Where username='{username}'";

                cmd.Connection = con;
                cmd.CommandText = query;

                var reader = cmd.ExecuteReader();
                List<Login> result = new List<Login>();
                Table table;
                if (username != null && password != null)
                {
                    table = _context.Tables.Find(username);
                    if(table.password == password)
                    {
                        return View("~/Views/Table/Router.cshtml");
                    }
                }
                else
                {
                    return View();
                }

            }
            /*
            while (reader.Read())
            {
                var d = new Login();
                d.name = (string)reader[0]; // Probably needs fixing
                d.surname = (string)reader[1]; // Probably needs fixing
                d.gsm = (string)reader[2]; // Probably needs fixing
                d.adress = (string)reader[3]; // Probably needs fixing
                d.username = (string)reader[4]; // Probably needs fixing
                d.password = (string)reader[5]; // Probably needs fixing
                d.status = (string)reader[6]; // Probably needs fixing
                result.Add(d);
            }
            */
            //reader.Close();
             
               return View("~/Views/Shared/Error.cshtml");

            
        }
    }
}
