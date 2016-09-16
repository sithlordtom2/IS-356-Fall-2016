using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IS356Main.Data;
using IS356Main.Models;

namespace IS356Main.Controllers
{
    public class PresentationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PresentationsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Presentations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Presentations.ToListAsync());
        }

        // GET: Presentations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentations = await _context.Presentations.SingleOrDefaultAsync(m => m.ID == id);
            if (presentations == null)
            {
                return NotFound();
            }

            return View(presentations);
        }

        // GET: Presentations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Presentations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Presenters,pLink,pPicture,pTitle")] Presentations presentations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presentations);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Admin");
            }
            return View(presentations);
        }

        // GET: Presentations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentations = await _context.Presentations.SingleOrDefaultAsync(m => m.ID == id);
            if (presentations == null)
            {
                return NotFound();
            }
            return View(presentations);
        }

        // POST: Presentations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Presenters,pLink,pPicture,pTitle")] Presentations presentations)
        {
            if (id != presentations.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presentations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresentationsExists(presentations.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Admin");
            }
            return View(presentations);
        }

        // GET: Presentations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentations = await _context.Presentations.SingleOrDefaultAsync(m => m.ID == id);
            if (presentations == null)
            {
                return NotFound();
            }

            return View(presentations);
        }

        // POST: Presentations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presentations = await _context.Presentations.SingleOrDefaultAsync(m => m.ID == id);
            _context.Presentations.Remove(presentations);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Admin");
        }

        private bool PresentationsExists(int id)
        {
            return _context.Presentations.Any(e => e.ID == id);
        }
    }
}
