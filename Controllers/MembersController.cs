using Microsoft.AspNetCore.Mvc;
using NewFolder.Data;
using NewFolder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NewFolder.Controllers;

namespace NewFolder.Controllers
{
    public class MembersController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public MembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🔒 Helper function for staff check
        private bool IsStaff()
        {
            return HttpContext.Session.GetString("Role") == "Staff";
        }

        // GET: Members
        public IActionResult Index()
        {
            var members = _context.Members.ToList();
            return View(members);
        }

        // GET: Members/Details/5
        public IActionResult Details(int id)
        {
            var member = _context.Members.Find(id);
            if (member == null) return NotFound();

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");
            return View();
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Member member)
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                _context.Members.Add(member);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public IActionResult Edit(int id)
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");

            var member = _context.Members.Find(id);
            if (member == null) return NotFound();

            return View(member);
        }

        // POST: Members/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Member member)
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                _context.Members.Update(member);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public IActionResult Delete(int id)
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");

            var member = _context.Members.Find(id);
            if (member == null) return NotFound();

            return View(member);
        }

        // POST: Members/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");

            var member = _context.Members.Find(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
