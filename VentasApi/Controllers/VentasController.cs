using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasApi.Data;
using VentasApi.Models;
using VentasApi.Dtos;

namespace VentasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VentasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            var ventas = await _context.Ventas.ToListAsync();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVentaById(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null) return NotFound();
            return Ok(venta);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Venta>> CreateVenta(VentaCreateDto dto)
        {
            var venta = new Venta
            {
                Concepto = dto.Concepto,
                Monto = dto.Monto
            };
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVentaById), new { id = venta.Id }, venta);
        }

        [HttpDelete("all")]
        [Authorize]
        public async Task<IActionResult> DeleteAllVentas()
        {
            var all = await _context.Ventas.ToListAsync();
            if (all.Count == 0) return NoContent();

            _context.Ventas.RemoveRange(all);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
