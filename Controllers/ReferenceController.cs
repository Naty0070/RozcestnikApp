using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RozcestnikApp.Data;
using RozcestnikApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RozcestnikApp.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly AppDbContext _context;

        public ReferenceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Reference> ListRef = _context.ReferencesDb.OrderBy(x => x.Order).ThenBy(x => x.Title);
            return View(ListRef);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reference obj)
        {
            if(ModelState.IsValid)
            {
                _context.ReferencesDb.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Admin","Section");
            }
            return View(obj);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var refFromDb = _context.ReferencesDb.Find(id);
            if (refFromDb == null)
            {
                return NotFound();
            }
            return View(refFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Reference obj)
        {
            if(ModelState.IsValid)
            {
                _context.ReferencesDb.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Admin", "Section");
            }
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            var categoryFromDb = _context.ReferencesDb.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteRef(int id)
        {
                var obj = _context.ReferencesDb.Find(id);
                _context.ReferencesDb.Remove(obj);
                _context.SaveChanges();
            return RedirectToAction("Admin", "Section");

        }

        public IActionResult Pass(string pass)
        {
            if (pass != "admin")
                return View();
            else
                return RedirectToAction("Admin", "Section");
        }
        public IActionResult Admin()
        {
            IEnumerable<Reference> ListOdkazu = _context.ReferencesDb.OrderBy(x => x.Order).ThenBy(x => x.Title);
            return View(ListOdkazu);

        }
    }
}
