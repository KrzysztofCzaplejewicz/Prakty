using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FutbolAmerykanski.DataContext;
using FutbolAmerykanski.Models;

namespace FutbolAmerykanski.Controllers
{
    public class LigasController : Controller
    {
        private readonly LigaContext _context;

        public LigasController(LigaContext context)
        {
            _context = context;
        }

        // GET: Ligas
        public async Task<IActionResult> Index()
        {
            var ligaContext = _context.Ligas.Include(l => l.DruzynyModel).Include(l => l.Zawodnik);
            return View(await ligaContext.ToListAsync());
        }

        // GET: Ligas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liga = await _context.Ligas
                .Include(l => l.DruzynyModel)
                .Include(l => l.Zawodnik)
                .SingleOrDefaultAsync(m => m.LigaId == id);
            if (liga == null)
            {
                return NotFound();
            }

            return View(liga);
        }

        // GET: Ligas/Create
        public IActionResult Create()
        {
            ViewData["IdDruzyny"] = new SelectList(_context.DruzynaModels, "IdDruzyny", "IdDruzyny");
            ViewData["IdZawodnik"] = new SelectList(_context.Zawodniks, "IdZawodnik", "IdZawodnik");
            return View();
        }

        // POST: Ligas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LigaId,IdZawodnik,IdDruzyny,Grade")] Liga liga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(liga);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IdDruzyny"] = new SelectList(_context.DruzynaModels, "IdDruzyny", "IdDruzyny");
            ViewData["IdZawodnik"] = new SelectList(_context.Zawodniks, "IdZawodnik", "IdZawodnik");
            return View(liga);
        }

        // GET: Ligas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liga = await _context.Ligas.SingleOrDefaultAsync(m => m.LigaId == id);
            if (liga == null)
            {
                return NotFound();
            }
            ViewData["IdDruzyny"] = new SelectList(_context.DruzynaModels, "IdDruzyny", "IdDruzyny");
            ViewData["IdZawodnik"] = new SelectList(_context.Zawodniks, "IdZawodnik", "IdZawodnik");
            return View(liga);
        }

        // POST: Ligas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LigaId,IdZawodnik,IdDruzyny,Grade")] Liga liga)
        {
            if (id != liga.LigaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(liga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LigaExists(liga.LigaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["IdDruzyny"] = new SelectList(_context.DruzynaModels, "IdDruzyny", "IdDruzyny");
            ViewData["IdZawodnik"] = new SelectList(_context.Zawodniks, "IdZawodnik", "IdZawodnik");
            return View(liga);
        }

        // GET: Ligas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liga = await _context.Ligas
                .Include(l => l.DruzynyModel)
                .Include(l => l.Zawodnik)
                .SingleOrDefaultAsync(m => m.LigaId == id);
            if (liga == null)
            {
                return NotFound();
            }

            return View(liga);
        }

        // POST: Ligas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var liga = await _context.Ligas.SingleOrDefaultAsync(m => m.LigaId == id);
            _context.Ligas.Remove(liga);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LigaExists(int id)
        {
            return _context.Ligas.Any(e => e.LigaId == id);
        }
    }
}
