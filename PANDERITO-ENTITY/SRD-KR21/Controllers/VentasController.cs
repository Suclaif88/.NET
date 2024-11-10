using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; // Agregar para logging
using SalesManagementApp.Data;
using SalesManagementApp.Models;

namespace SalesManagementApp.Controllers
{
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<VentasController> _logger;

        public VentasController(ApplicationDbContext context, ILogger<VentasController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var ventas = _context.Venta.Include(v => v.Cliente);
            return View(await ventas.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta
                .Include(v => v.Cliente)
                .Include(v => v.Detalles)
                .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(m => m.VentaId == id);

            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nombre");
            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentaId,Fecha,Total,ClienteId")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    venta.Fecha = DateTime.Now;
                    _context.Add(venta);

                    _logger.LogInformation("Attempting to save venta to the database: {@venta}", venta);

                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Venta saved successfully with ID: {VentaId}", venta.VentaId);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while saving the venta.");
                    ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again.");
                }
            }
            else
            {
                // Log each error in the model state
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _logger.LogWarning("Model validation error: {ErrorMessage}", error.ErrorMessage);
                    }
                }
            }

            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nombre", venta.ClienteId);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nombre", venta.ClienteId);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentaId,Fecha,Total,ClienteId")] Venta venta)
        {
            if (id != venta.VentaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.VentaId))
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

            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nombre", venta.ClienteId);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(m => m.VentaId == id);

            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Venta.FindAsync(id);
            if (venta != null)
            {
                _context.Venta.Remove(venta);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.Venta.Any(e => e.VentaId == id);
        }
    }
}
