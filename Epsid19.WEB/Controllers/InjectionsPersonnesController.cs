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
    public class InjectionsPersonnesController : Controller
    {
        private readonly Contexte _context;

        public InjectionsPersonnesController(Contexte context)
        {
            _context = context;
        }

        // GET: InjectionsPersonnes
        public async Task<IActionResult> Index()
        {
            var contexte = _context.InjectionsPersonnes.Include(i => i.Injections).Include(i => i.Personnes);
            return View(await contexte.ToListAsync());
        }

        // GET: InjectionsPersonnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injectionsPersonnes = await _context.InjectionsPersonnes
                .Include(i => i.Injections)
                .Include(i => i.Personnes)
                .FirstOrDefaultAsync(m => m.InjectionsId == id);
            if (injectionsPersonnes == null)
            {
                return NotFound();
            }

            return View(injectionsPersonnes);
        }

        // GET: InjectionsPersonnes/Create
        public IActionResult Create()
        {
            ViewData["InjectionsId"] = new SelectList(_context.Injections, "Id", "Id");
            ViewData["PersonnesId"] = new SelectList(_context.Personnes, "Id", "Id");
            return View();
        }

        // POST: InjectionsPersonnes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InjectionsId,PersonnesId")] InjectionsPersonnes injectionsPersonnes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(injectionsPersonnes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InjectionsId"] = new SelectList(_context.Injections, "Id", "Id", injectionsPersonnes.InjectionsId);
            ViewData["PersonnesId"] = new SelectList(_context.Personnes, "Id", "Id", injectionsPersonnes.PersonnesId);
            return View(injectionsPersonnes);
        }

        // GET: InjectionsPersonnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injectionsPersonnes = await _context.InjectionsPersonnes.FindAsync(id);
            if (injectionsPersonnes == null)
            {
                return NotFound();
            }
            ViewData["InjectionsId"] = new SelectList(_context.Injections, "Id", "Id", injectionsPersonnes.InjectionsId);
            ViewData["PersonnesId"] = new SelectList(_context.Personnes, "Id", "Id", injectionsPersonnes.PersonnesId);
            return View(injectionsPersonnes);
        }

        // POST: InjectionsPersonnes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InjectionsId,PersonnesId")] InjectionsPersonnes injectionsPersonnes)
        {
            if (id != injectionsPersonnes.InjectionsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(injectionsPersonnes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InjectionsPersonnesExists(injectionsPersonnes.InjectionsId))
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
            ViewData["InjectionsId"] = new SelectList(_context.Injections, "Id", "Id", injectionsPersonnes.InjectionsId);
            ViewData["PersonnesId"] = new SelectList(_context.Personnes, "Id", "Id", injectionsPersonnes.PersonnesId);
            return View(injectionsPersonnes);
        }

        // GET: InjectionsPersonnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injectionsPersonnes = await _context.InjectionsPersonnes
                .Include(i => i.Injections)
                .Include(i => i.Personnes)
                .FirstOrDefaultAsync(m => m.InjectionsId == id);
            if (injectionsPersonnes == null)
            {
                return NotFound();
            }

            return View(injectionsPersonnes);
        }

        // POST: InjectionsPersonnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var injectionsPersonnes = await _context.InjectionsPersonnes.FindAsync(id);
            _context.InjectionsPersonnes.Remove(injectionsPersonnes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InjectionsPersonnesExists(int id)
        {
            return _context.InjectionsPersonnes.Any(e => e.InjectionsId == id);
        }
    }
}
