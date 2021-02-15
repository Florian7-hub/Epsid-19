using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Epsid19;
using Epsid19.ORM;

namespace Epsid19.WEB.Controllers
{
    public class InjectionsController : Controller
    {
        private readonly Contexte _context;

        public InjectionsController(Contexte context)
        {
            _context = context;
        }

        // GET: Injections
        public async Task<IActionResult> Index()
        {
            return View(await _context.Injections.ToListAsync());
        }

        // GET: Injections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injections = await _context.Injections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (injections == null)
            {
                return NotFound();
            }

            return View(injections);
        }

        // GET: Injections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Injections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marque,NumLot,DateInjection,DateRappel,TypeVaccin")] Injections injections)
        {
            if (ModelState.IsValid)
            {
                _context.Add(injections);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(injections);
        }

        // GET: Injections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injections = await _context.Injections.FindAsync(id);
            if (injections == null)
            {
                return NotFound();
            }
            return View(injections);
        }

        // POST: Injections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marque,NumLot,DateInjection,DateRappel,TypeVaccin")] Injections injections)
        {
            if (id != injections.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(injections);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InjectionsExists(injections.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(injections);
        }

        // GET: Injections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injections = await _context.Injections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (injections == null)
            {
                return NotFound();
            }

            return View(injections);
        }

        // POST: Injections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var injections = await _context.Injections.FindAsync(id);
            _context.Injections.Remove(injections);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InjectionsExists(int id)
        {
            return _context.Injections.Any(e => e.Id == id);
        }
    }
}
