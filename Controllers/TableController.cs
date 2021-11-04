using Microsoft.AspNetCore.Mvc;
using LoginPage.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LoginPage.Controllers
{
    public class TableController : Controller
    {
        private readonly TableContext _context;

        public string getString(string KEY)
        {
            return HttpContext.Session.GetString(KEY);
        }
        public TableController(TableContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            string logSituation = getString("Login");

            if(logSituation == "true")
            {
                ViewBag.Session = getString("Status");
                var list = _context.Tables.ToList();
                return View(list);
            }
            else
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            
        }
        public IActionResult Table(string username)
        {
            Table table;
            if (username == null)
            {
                table = new Table();
            }
            else
            {
                table = _context.Tables.Find(username);
            }
            return View(table);
        }
        public async Task<IActionResult> Create(Table table)
        {
            if (table.name != null)
            {
                await _context.AddAsync(table);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string username)
        {
            using (var table = new TableContext())
            {
                var userList = table.Tables
                    .Where(x => x.username == username)
                    .First();
                table.Tables.Remove(userList);
                table.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(Table table)
        {
            using (var newTable = new TableContext())
            {
                var userList = newTable.Tables
                    .Where(x => x.username == table.username)
                    .First();
                
                userList.gsm = table.gsm;
                userList.name = table.name;
                userList.password = table.password;
                userList.surname = table.surname;
                          
                newTable.SaveChanges();
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
