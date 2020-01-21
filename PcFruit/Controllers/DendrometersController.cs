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
    public class DendrometersController : ControllerBase
    {
        private readonly PcfruitContext _context;

        public DendrometersController(PcfruitContext context)
        {
            _context = context;
        }

        // GET: api/Dendrometers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dendrometer>>> GetDendrometers()
        {
            return await _context.Dendrometers.ToListAsync();
        }

        // GET: api/Dendrometers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dendrometer>> GetDendrometer(int id)
        {
            var dendrometer = await _context.Dendrometers.FindAsync(id);

            if (dendrometer == null)
            {
                return NotFound();
            }

            return dendrometer;
        }

        // PUT: api/Dendrometers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDendrometer(int id, Dendrometer dendrometer)
        {
            if (id != dendrometer.DendrometerID)
            {
                return BadRequest();
            }

            _context.Entry(dendrometer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DendrometerExists(id))
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

        // POST: api/Dendrometers
        [HttpPost]
        public async Task<ActionResult<Dendrometer>> PostDendrometer(Dendrometer dendrometer)
        {
            _context.Dendrometers.Add(dendrometer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDendrometer", new { id = dendrometer.DendrometerID }, dendrometer);
        }

        // DELETE: api/Dendrometers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dendrometer>> DeleteDendrometer(int id)
        {
            var dendrometer = await _context.Dendrometers.FindAsync(id);
            if (dendrometer == null)
            {
                return NotFound();
            }

            _context.Dendrometers.Remove(dendrometer);
            await _context.SaveChangesAsync();

            return dendrometer;
        }

        private bool DendrometerExists(int id)
        {
            return _context.Dendrometers.Any(e => e.DendrometerID == id);
        }
    }
}
