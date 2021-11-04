using Microsoft.AspNetCore.Mvc;
using LoginPage.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

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
            username = username.Trim(charsToTrim);
            Table table;
            HttpContext.Session.SetString("Login", "false");
            if (username != null && password != null)
            {
                table = _context.Tables.Find(username);
                if (table.password == password)
                {
                    HttpContext.Session.SetString("Login", "true");
                    HttpContext.Session.SetString("Status", table.status);
                    return RedirectToAction("Index", "Table");
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
