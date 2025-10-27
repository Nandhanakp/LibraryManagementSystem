using Microsoft.AspNetCore.Mvc;
using NewFolder.Data;
using System.Linq;
using NewFolder.Controllers;

namespace NewFolder.Controllers
{
    public class MessagesController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public MessagesController(ApplicationDbContext context) => _context = context;

        private bool IsStaff() => HttpContext.Session.GetString("Role") == "Staff";

        // GET: Messages (Staff Only)
        public IActionResult Index()
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");

            var messages = _context.Messages
                                   .OrderByDescending(m => m.SentAt)
                                   .ToList();
            return View(messages);
        }
    }
}
