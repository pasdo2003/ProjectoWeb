using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CEBodyPlanet.Models;

namespace CEBodyPlanet.Controllers
{
    public class MarcaController : Controller
    {
        private readonly WebContext _context;

        public MarcaController(WebContext context)
        {
            _context = context;
        }

        // GET: Marca
        public async Task<IActionResult> Index()
        {
              return _context.Marca != null ? 
                          View(await _context.Marca.ToListAsync()) :
                          Problem("Entity set 'WebContext.Marca'  is null.");
        }

        // GET: Marca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Marca == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca
                .FirstOrDefaultAsync(m => m.Id_Marca == id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // GET: Marca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Marca,NomnbreMarca")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // GET: Marca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Marca == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        // POST: Marca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Marca,NomnbreMarca")] Marca marca)
        {
            if (id != marca.Id_Marca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaExists(marca.Id_Marca))
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
            return View(marca);
        }

        // GET: Marca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Marca == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca
                .FirstOrDefaultAsync(m => m.Id_Marca == id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // POST: Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Marca == null)
            {
                return Problem("Entity set 'WebContext.Marca'  is null.");
            }
            var marca = await _context.Marca.FindAsync(id);
            if (marca != null)
            {
                _context.Marca.Remove(marca);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaExists(int id)
        {
          return (_context.Marca?.Any(e => e.Id_Marca == id)).GetValueOrDefault();
        }
    }
}
