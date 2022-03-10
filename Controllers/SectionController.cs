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
    public class SectionController : Controller
    {
        private readonly AppDbContext _context;
        public SectionController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable < Section > ListSection = _context.SectionsDb.Include(x=>x.References);
            Section.Sections = _context.SectionsDb.ToList();
            return View(ListSection);
        }
        public IActionResult Admin()
        {
            IEnumerable<Section> ListSection = _context.SectionsDb.Include(x => x.References);
            Section.Sections = _context.SectionsDb.ToList();
            return View(ListSection);
        }

         [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Section obj)
        {
            if (ModelState.IsValid)
            {
                _context.SectionsDb.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Admin", "Section");
            }
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            var sekce = _context.SectionsDb.Find(id);
            if (sekce == null)
            {
                return NotFound();
            }
            return View(sekce);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSec(int id)
        {
            var obj = _context.SectionsDb.Find(id);
            _context.SectionsDb.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Admin", "Section");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var sekce = _context.SectionsDb.Find(id);
            if (sekce == null)
            {
                return NotFound();
            }
            return View(sekce);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Section obj)
        {
            if (ModelState.IsValid)
            {
                _context.SectionsDb.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Admin", "Section");
            }
            return View(obj);
        }

    }
}
