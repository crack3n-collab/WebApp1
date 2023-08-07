using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FYP2.Areas.Identity.Data;
using FYP2.Model;

namespace WebApp1.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly ILogger<MenuItemController> _logger;
        private readonly WebApp1IdentityDbContext _context;

        public MenuItemController(WebApp1IdentityDbContext context, ILogger<MenuItemController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: MenuItem
        public async Task<IActionResult> Index()
        {
            var webApp1IdentityDbContext = _context.MenuItem.Include(m => m.Cat);
            return View(await webApp1IdentityDbContext.ToListAsync());
        }

        // GET: MenuItem/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.MenuItem == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItem
                .Include(m => m.Cat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // GET: MenuItem/Create
        public IActionResult Create()
        {
            ViewData["CatId"] = new SelectList(_context.Category, "Id", "Id");
            return View();
        }

        // POST: MenuItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CatId,Iname,Price,Idescription")] MenuItem menuItem)
        {

            _logger.LogDebug("enter create post");



            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(menuItem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    // _logger.LogError("error: {msg}", ex.Message);
                    // error: An error occurred while saving the entity changes. See the inner exception for details.
                    // Check if the exception message contains "Violation of PRIMARY KEY constraint"
                    if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY constraint"))
                    {
                        ModelState.AddModelError(string.Empty,
                            string.Format("Id '{0}' already exists.", menuItem.Id));
                    }
                    else
                    {

                        ModelState.AddModelError(string.Empty,
                            "An error occured - please contact your system administrator.");
                    }

                }

            }
            _logger.LogDebug("model not valie: {errorCount}", ModelState.ErrorCount);
            ViewData["CatId"] = new SelectList(_context.Category, "Id", "Id", menuItem.CatId);
            return View(menuItem);
        }



        // GET: MenuItem/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.MenuItem == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItem.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            ViewData["CatId"] = new SelectList(_context.Category, "Id", "Id", menuItem.CatId);
            return View(menuItem);
        }

        // POST: MenuItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,CatId,Iname,Price,Idescription")] MenuItem menuItem)
        {
            if (id != menuItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuItemExists(menuItem.Id))
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
            ViewData["CatId"] = new SelectList(_context.Category, "Id", "Id", menuItem.CatId);
            return View(menuItem);
        }

        // GET: MenuItem/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.MenuItem == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItem
                .Include(m => m.Cat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // POST: MenuItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.MenuItem == null)
            {
                return Problem("Entity set 'WebApp1IdentityDbContext.MenuItem'  is null.");
            }
            var menuItem = await _context.MenuItem.FindAsync(id);
            if (menuItem != null)
            {
                _context.MenuItem.Remove(menuItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuItemExists(string id)
        {
          return (_context.MenuItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
