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
    public class LinksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LinksController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Links
        public async Task<IActionResult> Index()
        {
            return View(await _context.Links.ToListAsync());
        }

        // GET: Links/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var links = await _context.Links.SingleOrDefaultAsync(m => m.ID == id);
            if (links == null)
            {
                return NotFound();
            }

            return View(links);
        }

        // GET: Links/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Links/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,link,linkPicture")] Links links)
        {
            if (ModelState.IsValid)
            {
                _context.Add(links);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Admin");
            }
            return View(links);
        }

        // GET: Links/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var links = await _context.Links.SingleOrDefaultAsync(m => m.ID == id);
            if (links == null)
            {
                return NotFound();
            }
            return View(links);
        }

        // POST: Links/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,link,linkPicture")] Links links)
        {
            if (id != links.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(links);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinksExists(links.ID))
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
            return View(links);
        }

        // GET: Links/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var links = await _context.Links.SingleOrDefaultAsync(m => m.ID == id);
            if (links == null)
            {
                return NotFound();
            }

            return View(links);
        }

        // POST: Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var links = await _context.Links.SingleOrDefaultAsync(m => m.ID == id);
            _context.Links.Remove(links);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Admin");
        }

        private bool LinksExists(int id)
        {
            return _context.Links.Any(e => e.ID == id);
        }
    }
}
