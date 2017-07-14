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
    public class DruzynaModelsController : Controller
    {
        private readonly LigaContext _context;

        public DruzynaModelsController(LigaContext context)
        {
            _context = context;    
        }

        // GET: DruzynaModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.DruzynaModels.ToListAsync());
        }

        // GET: DruzynaModels/Details/5
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

        // GET: DruzynaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DruzynaModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDruzyny,Nazwa,Miasto")] DruzynaModel druzynaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(druzynaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(druzynaModel);
        }

        // GET: DruzynaModels/Edit/5
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

        // POST: DruzynaModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDruzyny,Nazwa,Miasto")] DruzynaModel druzynaModel)
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

        // GET: DruzynaModels/Delete/5
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

        // POST: DruzynaModels/Delete/5
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
