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
    public class SkladController : Controller
    {
        private readonly LigaContext _context;

        public SkladController(LigaContext context)
        {
            _context = context;    
        }

        // GET: Sklad
        public async Task<IActionResult> Index()
        {
            return View(await _context.DruzynaModels.ToListAsync());
        }

        // GET: Sklad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var druzynaModel = await _context.DruzynaModels
                .SingleOrDefaultAsync(m => m.IdDruzyny == id);
            if (druzynaModel == null)
            {
                return NotFound();
            }

            return View(druzynaModel);
        }

        // GET: Sklad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sklad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDruzyny,Nazwa,Miasto,Imie,Nazwisko")] DruzynaModel druzynaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(druzynaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(druzynaModel);
        }

        // GET: Sklad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var druzynaModel = await _context.DruzynaModels.SingleOrDefaultAsync(m => m.IdDruzyny == id);
            if (druzynaModel == null)
            {
                return NotFound();
            }
            return View(druzynaModel);
        }

        // POST: Sklad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDruzyny,Nazwa,Miasto,Imie,Nazwisko")] DruzynaModel druzynaModel)
        {
            if (id != druzynaModel.IdDruzyny)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(druzynaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DruzynaModelExists(druzynaModel.IdDruzyny))
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
            return View(druzynaModel);
        }

        // GET: Sklad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var druzynaModel = await _context.DruzynaModels
                .SingleOrDefaultAsync(m => m.IdDruzyny == id);
            if (druzynaModel == null)
            {
                return NotFound();
            }

            return View(druzynaModel);
        }

        // POST: Sklad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var druzynaModel = await _context.DruzynaModels.SingleOrDefaultAsync(m => m.IdDruzyny == id);
            _context.DruzynaModels.Remove(druzynaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DruzynaModelExists(int id)
        {
            return _context.DruzynaModels.Any(e => e.IdDruzyny == id);
        }
    }
}
