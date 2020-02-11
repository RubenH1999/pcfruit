using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcFruit.Models;

namespace PcFruit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecsController : ControllerBase
    {
        private readonly PcfruitContext _context;

        public SpecsController(PcfruitContext context)
        {
            _context = context;
        }

        // GET: api/Specs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spec>>> GetSpec()
        {
            return await _context.Spec.ToListAsync();
        }

        // GET: api/Specs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spec>> GetSpec(long id)
        {
            var spec = await _context.Spec.FindAsync(id);

            if (spec == null)
            {
                return NotFound();
            }

            return spec;
        }

        // PUT: api/Specs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpec(long id, Spec spec)
        {
            if (id != spec.SpecID)
            {
                return BadRequest();
            }

            _context.Entry(spec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecExists(id))
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

        // POST: api/Specs
        [HttpPost]
        public async Task<ActionResult<Spec>> PostSpec(Spec spec)
        {
            _context.Spec.Add(spec);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpec", new { id = spec.SpecID }, spec);
        }

        // DELETE: api/Specs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Spec>> DeleteSpec(long id)
        {
            var spec = await _context.Spec.FindAsync(id);
            if (spec == null)
            {
                return NotFound();
            }

            _context.Spec.Remove(spec);
            await _context.SaveChangesAsync();

            return spec;
        }

        private bool SpecExists(long id)
        {
            return _context.Spec.Any(e => e.SpecID == id);
        }
    }
}
