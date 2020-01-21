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
    public class ThermometersController : ControllerBase
    {
        private readonly PcfruitContext _context;

        public ThermometersController(PcfruitContext context)
        {
            _context = context;
        }

        // GET: api/Thermometers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thermometer>>> GetThermometers()
        {
            return await _context.Thermometers.ToListAsync();
        }

        // GET: api/Thermometers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thermometer>> GetThermometer(int id)
        {
            var thermometer = await _context.Thermometers.FindAsync(id);

            if (thermometer == null)
            {
                return NotFound();
            }

            return thermometer;
        }

        // PUT: api/Thermometers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThermometer(int id, Thermometer thermometer)
        {
            if (id != thermometer.ThermometerID)
            {
                return BadRequest();
            }

            _context.Entry(thermometer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThermometerExists(id))
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

        // POST: api/Thermometers
        [HttpPost]
        public async Task<ActionResult<Thermometer>> PostThermometer(Thermometer thermometer)
        {
            _context.Thermometers.Add(thermometer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThermometer", new { id = thermometer.ThermometerID }, thermometer);
        }

        // DELETE: api/Thermometers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Thermometer>> DeleteThermometer(int id)
        {
            var thermometer = await _context.Thermometers.FindAsync(id);
            if (thermometer == null)
            {
                return NotFound();
            }

            _context.Thermometers.Remove(thermometer);
            await _context.SaveChangesAsync();

            return thermometer;
        }

        private bool ThermometerExists(int id)
        {
            return _context.Thermometers.Any(e => e.ThermometerID == id);
        }
    }
}
