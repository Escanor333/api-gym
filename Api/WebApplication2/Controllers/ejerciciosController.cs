using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ejerciciosController : ControllerBase
    {
        private readonly WebApplication2Context _context;

        public ejerciciosController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: api/ejercicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ejercicio>>> Getejercicio()
        {
            return await _context.ejercicio.ToListAsync();
        }

        // GET: api/ejercicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ejercicio>> Getejercicio(int id)
        {
            var ejercicio = await _context.ejercicio.FindAsync(id);

            if (ejercicio == null)
            {
                return NotFound();
            }

            return ejercicio;
        }

        // PUT: api/ejercicios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putejercicio(int id, ejercicio ejercicio)
        {
            if (id != ejercicio.Id)
            {
                return BadRequest();
            }

            _context.Entry(ejercicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ejercicioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ejercicios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ejercicio>> Postejercicio(ejercicio ejercicio)
        {
            _context.ejercicio.Add(ejercicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getejercicio", new { id = ejercicio.Id }, ejercicio);
        }

        // DELETE: api/ejercicios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ejercicio>> Deleteejercicio(int id)
        {
            var ejercicio = await _context.ejercicio.FindAsync(id);
            if (ejercicio == null)
            {
                return NotFound();
            }

            _context.ejercicio.Remove(ejercicio);
            await _context.SaveChangesAsync();

            return ejercicio;
        }

        private bool ejercicioExists(int id)
        {
            return _context.ejercicio.Any(e => e.Id == id);
        }
    }
}
