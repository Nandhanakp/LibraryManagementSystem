using Microsoft.AspNetCore.Mvc;
using NewFolder.Models;
using NewFolder.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;
using NewFolder.Controllers;

namespace NewFolder.Controllers
{
    public class ServicesController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🔒 Helper function for staff check
        private bool IsStaff()
        {
            return HttpContext.Session.GetString("Role") == "Staff";
        }

        // GET: Services
        public IActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");
            return View();
        }

        // POST: Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // (Optional: Add Edit/Delete later with similar staff checks)
    }
}
