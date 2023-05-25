using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CEBodyPlanet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CEBodyPlanet.Controllers
{
    public class PersonaController : Controller
    {
        private readonly WebContext _context;
        public PersonaController(WebContext context)
        {
            _context = context;
        }

        // URL: /Persona
        [HttpGet]
        public async Task<IActionResult> Index()
        {
         return View(await _context.Persona.ToListAsync());
        }

        // URL: /Persona/CrearPersona
        public async Task<IActionResult> CrearPersonaAsync()
        {
            ViewData["Ciudades"] = await _context.Ciudad.ToListAsync();
            return View();
        }

        // POST: /Persona/CrearPersona
        [HttpPost]
        public async Task<IActionResult> CrearPersona(Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }
        // Persona/ConsultarPersona
        [HttpGet]
        public async Task<IActionResult> ConsultarPersona(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona.Include(p => p.Ciudad)
                .FirstOrDefaultAsync(m => m.Id_Persona == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Persona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }

            var paciente = await _context.Persona
                .Include(p => p.Ciudad)
                .FirstOrDefaultAsync(m => m.Id_Persona == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }
        // GET: Persona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["Id_Ciudad"] = new SelectList(_context.Ciudad, "Id_ciudad", "Nombre", persona.Id_Ciudad);
            return View(persona);
        }

        // POST: Persona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Persona persona)
        {
            if (id != persona.Id_Persona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.Id_Persona))
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
            ViewData["Id_Ciudad"] = new SelectList(_context.Ciudad, "Id_ciudad", "Nombre", persona.Id_Ciudad);
            return View(persona);
        }

        // GET: Persona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona
                .Include(p => p.Ciudad)
                .FirstOrDefaultAsync(m => m.Id_Persona == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Persona == null)
            {
                return Problem("Entity set 'AppContext.Paciente'  is null.");
            }
            var persona = await _context.Persona.FindAsync(id);
            if (persona != null)
            {
                _context.Persona.Remove(persona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return (_context.Persona?.Any(e => e.Id_Persona == id)).GetValueOrDefault();
        }
    }


}
