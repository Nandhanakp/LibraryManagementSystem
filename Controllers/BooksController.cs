using Microsoft.AspNetCore.Mvc;   // required for Controller, IActionResult, HttpPost, etc.
using Microsoft.EntityFrameworkCore;
using NewFolder.Data;             // for ApplicationDbContext
using NewFolder.Models;           // for Book model
using NewFolder.Controllers;

namespace NewFolder.Controllers
{
    public class BooksController : BaseController   // Controller comes from Microsoft.AspNetCore.Mvc
    {
        

        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }
        private bool IsStaff()
{
    return HttpContext.Session.GetString("Role") == "Staff";
}
        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }


       // GET: Books/Create
public IActionResult Create()
{
    if (!IsStaff()) return RedirectToAction("Login", "Account");
    return View();
}

// POST: Books/Create
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(Book book)
{
    if (!IsStaff()) return RedirectToAction("Login", "Account");

    if (ModelState.IsValid)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(book);
}




     // GET: Books/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (!IsStaff()) return RedirectToAction("Login", "Account");
    if (id == null) return NotFound();

    var book = await _context.Books.FindAsync(id);
    if (book == null) return NotFound();

    return View(book);
}

// POST: Books/Edit/5
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, Book book)
{
    if (!IsStaff()) return RedirectToAction("Login", "Account");
    if (id != book.Id) return NotFound();

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Books.Any(e => e.Id == book.Id))
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
    return View(book);
}

        // GET: Books/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (!IsStaff()) return RedirectToAction("Login", "Account");
    if (id == null) return NotFound();

    var book = await _context.Books
        .FirstOrDefaultAsync(m => m.Id == id);
    if (book == null) return NotFound();

    return View(book);
}

// POST: Books/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    if (!IsStaff()) return RedirectToAction("Login", "Account");

    var book = await _context.Books.FindAsync(id);
    if (book != null)
    {
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    return RedirectToAction(nameof(Index));
}

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null) return NotFound();

            return View(book);
        }

            }
}
