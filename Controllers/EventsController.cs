using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewFolder.Data;
using NewFolder.Models;
using NewFolder.Controllers;

namespace NewFolder.Controllers
{
    public class EventsController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🔒 Helper method for staff role check
        private bool IsStaff()
        {
            return HttpContext.Session.GetString("Role") == "Staff";
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.ToListAsync();
            return View(events);
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var eventItem = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);

            if (eventItem == null) return NotFound();

            return View(eventItem);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event eventItem)
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                _context.Add(eventItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventItem);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");
            if (id == null) return NotFound();

            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null) return NotFound();

            return View(eventItem);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Event eventItem)
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");
            if (id != eventItem.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Events.Any(e => e.Id == eventItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(eventItem);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");
            if (id == null) return NotFound();

            var eventItem = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventItem == null) return NotFound();

            return View(eventItem);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!IsStaff()) return RedirectToAction("Login", "Account");

            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem != null)
            {
                _context.Events.Remove(eventItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
