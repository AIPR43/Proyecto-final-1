using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tiendaweb.Models;

namespace tiendaweb.Controllers
{
    public class DetallesComprasController : Controller
    {
        private readonly tiendaContext _context;

        public DetallesComprasController(tiendaContext context)
        {
            _context = context;
        }

        // GET: DetallesCompras
        public async Task<IActionResult> Index()
        {
            var tiendaContext = _context.DetallesCompras.Include(d => d.Compra).Include(d => d.Producto);
            return View(await tiendaContext.ToListAsync());
        }

        // GET: DetallesCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetallesCompras == null)
            {
                return NotFound();
            }

            var detallesCompra = await _context.DetallesCompras
                .Include(d => d.Compra)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetalleId == id);
            if (detallesCompra == null)
            {
                return NotFound();
            }

            return View(detallesCompra);
        }

        // GET: DetallesCompras/Create
        public IActionResult Create()
        {
            ViewData["CompraId"] = new SelectList(_context.Compras, "CompraId", "CompraId");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId");
            return View();
        }

        // POST: DetallesCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetalleId,CompraId,ProductoId,Cantidad,PrecioUnitario")] DetallesCompra detallesCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallesCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompraId"] = new SelectList(_context.Compras, "CompraId", "CompraId", detallesCompra.CompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", detallesCompra.ProductoId);
            return View(detallesCompra);
        }

        // GET: DetallesCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetallesCompras == null)
            {
                return NotFound();
            }

            var detallesCompra = await _context.DetallesCompras.FindAsync(id);
            if (detallesCompra == null)
            {
                return NotFound();
            }
            ViewData["CompraId"] = new SelectList(_context.Compras, "CompraId", "CompraId", detallesCompra.CompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", detallesCompra.ProductoId);
            return View(detallesCompra);
        }

        // POST: DetallesCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalleId,CompraId,ProductoId,Cantidad,PrecioUnitario")] DetallesCompra detallesCompra)
        {
            if (id != detallesCompra.DetalleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallesCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesCompraExists(detallesCompra.DetalleId))
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
            ViewData["CompraId"] = new SelectList(_context.Compras, "CompraId", "CompraId", detallesCompra.CompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", detallesCompra.ProductoId);
            return View(detallesCompra);
        }

        // GET: DetallesCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetallesCompras == null)
            {
                return NotFound();
            }

            var detallesCompra = await _context.DetallesCompras
                .Include(d => d.Compra)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetalleId == id);
            if (detallesCompra == null)
            {
                return NotFound();
            }

            return View(detallesCompra);
        }

        // POST: DetallesCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetallesCompras == null)
            {
                return Problem("Entity set 'tiendaContext.DetallesCompras'  is null.");
            }
            var detallesCompra = await _context.DetallesCompras.FindAsync(id);
            if (detallesCompra != null)
            {
                _context.DetallesCompras.Remove(detallesCompra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesCompraExists(int id)
        {
          return (_context.DetallesCompras?.Any(e => e.DetalleId == id)).GetValueOrDefault();
        }
    }
}
