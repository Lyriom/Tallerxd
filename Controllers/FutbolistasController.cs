using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerClase.Models;
using Tallerxd.Data;

namespace Tallerxd.Controllers
{
    public class FutbolistasController : Controller
    {
        private readonly TallerxdContext _context;

        public FutbolistasController(TallerxdContext context)
        {
            _context = context;
        }

        // GET: Futbolistas
        public async Task<IActionResult> Index(int? equipoId)
        {
            // Cargar la lista de equipos para el filtro
            ViewBag.Equipos = new SelectList(await _context.Equipo.ToListAsync(), "Id", "Nombre");

            // Obtener la lista de futbolistas, incluyendo la relación con el equipo
            IQueryable<Futbolistas> futbolistas = _context.Futbolista.Include(f => f.Equipo);

            // Filtrar por equipo si se selecciona uno
            if (equipoId.HasValue)
            {
                futbolistas = futbolistas.Where(f => f.IdEquipo == equipoId.Value);
            }

            return View(await futbolistas.ToListAsync());
        }

        // GET: Futbolistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futbolista = await _context.Futbolista
                .Include(f => f.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (futbolista == null)
            {
                return NotFound();
            }

            return View(futbolista);
        }

        // GET: Futbolistas/Create
        public IActionResult Create()
        {
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre");
            return View();
        }

        // POST: Futbolistas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Posicion,Edad,IdEquipo")] Futbolistas futbolista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(futbolista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre", futbolista.IdEquipo);
            return View(futbolista);
        }

        // GET: Futbolistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futbolista = await _context.Futbolista.FindAsync(id);
            if (futbolista == null)
            {
                return NotFound();
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre", futbolista.IdEquipo);
            return View(futbolista);
        }

        // POST: Futbolistas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Posicion,Edad,IdEquipo")] Futbolistas futbolista)
        {
            if (id != futbolista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(futbolista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FutbolistaExists(futbolista.Id))
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
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre", futbolista.IdEquipo);
            return View(futbolista);
        }

        // GET: Futbolistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futbolista = await _context.Futbolista
                .Include(f => f.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (futbolista == null)
            {
                return NotFound();
            }

            return View(futbolista);
        }

        // POST: Futbolistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var futbolista = await _context.Futbolista.FindAsync(id);
            if (futbolista != null)
            {
                _context.Futbolista.Remove(futbolista);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FutbolistaExists(int id)
        {
            return _context.Futbolista.Any(e => e.Id == id);
        }
    }
}
