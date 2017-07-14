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
    public class ZawodniksController : Controller
    {
        private readonly LigaContext _context;

        public ZawodniksController(LigaContext context)
        {
            _context = context;    
        }

        // GET: Zawodniks
        public async Task<IActionResult> Index()
        {
            // ReSharper disable once Mvc.ViewNotResolved
            return View(await _context.Zawodniks.ToListAsync());
        }

        // GET: Zawodniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zawodnik = await _context.Zawodniks
                .SingleOrDefaultAsync(m => m.IdZawodnik == id);
            if (zawodnik == null)
            {
                return NotFound();
            }

            return View(zawodnik);
        }

        // GET: Zawodniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zawodniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZawodnik,Imie,Nazwisko,LigaDateTime")] Zawodnik zawodnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zawodnik);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(zawodnik);
        }

        // GET: Zawodniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zawodnik = await _context.Zawodniks.SingleOrDefaultAsync(m => m.IdZawodnik == id);
            if (zawodnik == null)
            {
                return NotFound();
            }
            return View(zawodnik);
        }

        // POST: Zawodniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZawodnik,Imie,Nazwisko,LigaDateTime")] Zawodnik zawodnik)
        {
            if (id != zawodnik.IdZawodnik)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zawodnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZawodnikExists(zawodnik.IdZawodnik))
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
            return View(zawodnik);
        }

        // GET: Zawodniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zawodnik = await _context.Zawodniks
                .SingleOrDefaultAsync(m => m.IdZawodnik == id);
            if (zawodnik == null)
            {
                return NotFound();
            }

            return View(zawodnik);
        }

        // POST: Zawodniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zawodnik = await _context.Zawodniks.SingleOrDefaultAsync(m => m.IdZawodnik == id);
            _context.Zawodniks.Remove(zawodnik);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ZawodnikExists(int id)
        {
            return _context.Zawodniks.Any(e => e.IdZawodnik == id);
        }
    }
}
