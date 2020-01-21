using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcFruit.Api.Requests;
using PcFruit.Models;

namespace PcFruit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly PcfruitContext _context;

        public MeasurementsController(PcfruitContext context)
        {
            _context = context;
        }

        // GET: api/Measurements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurement()
        {
            return await _context.Measurements
                .Include(m => m.Sensors)
                .Include(x => x.Module)
                .ToListAsync();
        }

        // GET: api/Measurements/5
       /* [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetMeasurement(int id)
        {
            var measurement = await _context.Measurements.FindAsync(id);

            if (measurement == null)
            {
                return NotFound();
            }

            return measurement;
        }*/

        // GET: api/Measurements/<modulename>
        [HttpGet("{name}")]
        public async Task<ActionResult<List<Measurement>>> GetMeasurementsOfModule(string name)
        {
            var measurements = _context.Measurements
                .Include(m => m.Module)
                .Include(m => m.Sensors)
                .Where(m => m.Module.Name == name).ToList();

            if (measurements.Count == 0)
                return NotFound("module '" + name + "' not found!");


            return measurements;
        }

        // PUT: api/Measurements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeasurement(int id, Measurement measurement)
        {
            if (id != measurement.MeasurementID)
            {
                return BadRequest();
            }

            _context.Entry(measurement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasurementExists(id))
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

        // POST: api/Measurements
        [HttpPost]
        public async Task<ActionResult<Measurement>> PostMeasurement(MeasurementRequest request)
        {
            // find module or register new one if it doesn't exist yet
            Module module = _context.Modules.FirstOrDefault(m => m.Name == request.Logger);
            if (module == null)
                module = new Module() { Name = request.Logger };

            // create measurement
            Measurement measurement = new Measurement() { 
                Module = module,
                TimeReceived = DateTime.Now,
                TimeRegistered = request.DateTime
            };

            // add the measurement values
            measurement.Sensors = request.Thermometers.Select(sensor => {
                sensor.Type = SensorType.Thermometer;
                return sensor;
            }).ToList();

            measurement.Sensors.AddRange(request.Dendrometers.Select(sensor => {
                sensor.Type = SensorType.Dendrometer;
                return sensor;
            }));

            // save the measurements in the database
            _context.Measurements.Add(measurement);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMeasurement", new { id = measurement.MeasurementID }, measurement);
        }

        // DELETE: api/Measurements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Measurement>> DeleteMeasurement(int id)
        {
            var measurement = await _context.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return NotFound();
            }

            _context.Measurements.Remove(measurement);
            await _context.SaveChangesAsync();

            return measurement;
        }

        private bool MeasurementExists(int id)
        {
            return _context.Measurements.Any(e => e.MeasurementID == id);
        }
    }
}
