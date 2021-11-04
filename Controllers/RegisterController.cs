using LoginPage.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
        public async Task<IActionResult> IndexAsync(string name, string surname, string gsm, string address, string username,
            string password, string re_password, string status)
        {
            //bool dublicated = false;
            char[] charsToTrim = { ' ' };
            username = username.Trim(charsToTrim);
            if (password == re_password)
            {

                int userCheck = 0;

                using (var table = new TableContext())
                {
                    userCheck = table.Tables
                        .Where(x => x.username == username)
                        .Count();
                }

                ViewBag.Message = "true";
                if ( userCheck > 0 )
                {
                    ViewBag.Message = "false";
                    return View("~/Views/Register/Index.cshtml");
                }

                Table CreateUser = new Table(name, surname, gsm, address, username,
            password, status);

                HttpContext.Session.SetString("Status", CreateUser.status);
                HttpContext.Session.SetString("Login", "true");

                if (CreateUser.name != null)
                {
                    await _context.AddAsync(CreateUser);
                }
                await _context.SaveChangesAsync();

                ViewBag.Status = CreateUser.status;
                return RedirectToAction("Index", "Table");
            }

            else
            {
                return View("~/Views/Register/Index.cshtml");
            }
        }
    }
}
