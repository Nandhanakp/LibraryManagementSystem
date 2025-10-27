using Microsoft.AspNetCore.Mvc;
using NewFolder.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using NewFolder.Controllers;

namespace NewFolder.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var member = _context.Members.FirstOrDefault(m => m.Email == email && m.Password == password);

            if (member != null)
            {
                // store session
                HttpContext.Session.SetString("Email", member.Email);
                HttpContext.Session.SetString("Role", member.Role ?? "");
                HttpContext.Session.SetString("UserName", member.Name );

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid email or password";
            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
