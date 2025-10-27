using Microsoft.AspNetCore.Mvc;
using NewFolder.Data;
using NewFolder.Models;
using NewFolder.Controllers;

namespace NewFolder.Controllers
{
    public class ContactController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool IsMember() => HttpContext.Session.GetString("Role") == "Member";

        // GET: Contact
        public IActionResult Index()
        {
            if (!IsMember()) return RedirectToAction("Login", "Account");
            return View();
        }

        // POST: Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Message message)
        {
            if (!IsMember()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                message.SentAt = DateTime.Now;  // Ensure timestamp
                _context.Messages.Add(message);
                _context.SaveChanges();
                ViewBag.Success = "Message sent successfully!";
                ModelState.Clear();  // Clear form
                return View();       // Show empty form again
            }

            return View(message);
        }
    }
}
