using Microsoft.AspNetCore.Mvc;
using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginPage.Controllers
{
    public class TableController  : Controller
    {
        private readonly TableContext _context;
        public TableController(TableContext context)
        {
            _context = context;
        }



        public IActionResult Index ()
        {
            var list = _context.Logins.ToList();
            return View(list);
        }
        public async Task<IActionResult> Create(Login login)
        {
            //var list = _context.Registers.ToList();
            //update
            // if (temp.GetType() != null)
            if (login.name != null)
            {
                await _context.AddAsync(login);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string name)
        {
            var login = await _context.Logins.FindAsync(name);
            _context.Remove(login);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Table(string name)
        {
            Login login;
            if (name != null)
            {
                login = _context.Logins.Find(name);

            }
            else
            {
                login = new Login();
            }
            return View(login);
        }
    }
}
