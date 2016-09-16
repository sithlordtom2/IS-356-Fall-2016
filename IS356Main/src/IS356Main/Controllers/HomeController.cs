using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IS356Main.Data;
using Microsoft.EntityFrameworkCore;

namespace IS356Main.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Groups.ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "System Development Life Cycle Project";

            return View();
        }

        public async Task<IActionResult> Contact()
        {
            ViewData["Message"] = "IS 356 Project - Fall 2016";

            return View(await _context.Contacts.ToListAsync());
        }

        public async Task<IActionResult> Present()
        {

            return View(await _context.Presentations.ToListAsync());
        }

        public IActionResult Helpful()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
