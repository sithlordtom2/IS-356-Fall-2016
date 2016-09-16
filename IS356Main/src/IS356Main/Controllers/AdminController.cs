using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IS356Main.Data;
using IS356Main.Models;

namespace IS356Main.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var adminModel = new Admin();
            adminModel.listGroups.AddRange(_dbContext.Groups);
            adminModel.listLinks.AddRange(_dbContext.Links);
            adminModel.listPresentations.AddRange(_dbContext.Presentations);
            adminModel.listContacts.AddRange(_dbContext.Contacts);
            if(User.IsInRole("Admin"))
            {
                return View(adminModel);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}