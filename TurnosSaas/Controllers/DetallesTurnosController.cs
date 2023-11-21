using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurnosSaas.Data;
using TurnosSaas.Models;

namespace TurnosSaas.Controllers
{
    public class DetallesTurnosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetallesTurnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetallesTurnos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Detalle_Turnos.Include(d => d.Producto).Include(d => d.Turno);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetallesTurnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detalle_Turnos == null)
            {
                return NotFound();
            }

            var detalle_Turno = await _context.Detalle_Turnos
                .Include(d => d.Producto)
                .Include(d => d.Turno)
                .FirstOrDefaultAsync(m => m.DetalleTurno == id);
            if (detalle_Turno == null)
            {
                return NotFound();
            }

            return View(detalle_Turno);
        }

        // GET: DetallesTurnos/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "Codigo");
            ViewData["TurnoId"] = new SelectList(_context.Turnos, "TurnoId", "Estado");
            return View();
        }

        // POST: DetallesTurnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetalleTurno,TurnoId,ProductoId,Cantidad,Precio")] Detalle_Turno detalle_Turno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalle_Turno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "Codigo", detalle_Turno.ProductoId);
            ViewData["TurnoId"] = new SelectList(_context.Turnos, "TurnoId", "Estado", detalle_Turno.TurnoId);
            return View(detalle_Turno);
        }

        // GET: DetallesTurnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Detalle_Turnos == null)
            {
                return NotFound();
            }

            var detalle_Turno = await _context.Detalle_Turnos.FindAsync(id);
            if (detalle_Turno == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "Codigo", detalle_Turno.ProductoId);
            ViewData["TurnoId"] = new SelectList(_context.Turnos, "TurnoId", "Estado", detalle_Turno.TurnoId);
            return View(detalle_Turno);
        }

        // POST: DetallesTurnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalleTurno,TurnoId,ProductoId,Cantidad,Precio")] Detalle_Turno detalle_Turno)
        {
            if (id != detalle_Turno.DetalleTurno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalle_Turno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Detalle_TurnoExists(detalle_Turno.DetalleTurno))
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
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "Codigo", detalle_Turno.ProductoId);
            ViewData["TurnoId"] = new SelectList(_context.Turnos, "TurnoId", "Estado", detalle_Turno.TurnoId);
            return View(detalle_Turno);
        }

        // GET: DetallesTurnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Detalle_Turnos == null)
            {
                return NotFound();
            }

            var detalle_Turno = await _context.Detalle_Turnos
                .Include(d => d.Producto)
                .Include(d => d.Turno)
                .FirstOrDefaultAsync(m => m.DetalleTurno == id);
            if (detalle_Turno == null)
            {
                return NotFound();
            }

            return View(detalle_Turno);
        }

        // POST: DetallesTurnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Detalle_Turnos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Detalle_Turnos'  is null.");
            }
            var detalle_Turno = await _context.Detalle_Turnos.FindAsync(id);
            if (detalle_Turno != null)
            {
                _context.Detalle_Turnos.Remove(detalle_Turno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Detalle_TurnoExists(int id)
        {
          return (_context.Detalle_Turnos?.Any(e => e.DetalleTurno == id)).GetValueOrDefault();
        }
    }
}
