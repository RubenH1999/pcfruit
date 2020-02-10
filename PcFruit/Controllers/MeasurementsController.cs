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
        public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurements()
        {
            return await _context.Measurements.ToListAsync();
        }

        // GET: api/Measurements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetMeasurement(long id)
        {
            var measurement = await _context.Measurements.FindAsync(id);

            if (measurement == null)
            {
                return NotFound();
            }

            return measurement;
        }

        // PUT: api/Measurements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeasurement(long id, Measurement measurement)
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
            // get existing module or create new one if it doesn't exist yet
            Module module = await _context.Modules.FirstOrDefaultAsync(m => m.Name == request.Logger) ?? new Module
            {
                Name = request.Logger
            };

            var currentDate = DateTime.Now;

            // add received sensor data to the measurement
            foreach (SensorRequest sensor in request.Sensors)
            {
                Measurement measurement = new Measurement
                {
                    Module = module,
                    TimeReceived = request.DateTime,
                    TimeRegistered = currentDate
                };
                // determine sensor type and set value of the measurement based on that
                switch (sensor.GetType())
                {
                    case SensorType.Dendro:
                        measurement.Value = (double) sensor.Distance;
                        break;
                    case SensorType.Humidity:
                        measurement.Value = (double) sensor.Humidity;
                        break;
                    case SensorType.Thermo:
                        measurement.Value = (double) sensor.Temperature;
                        break;
                    default:
                        throw new Exception("Unknown sensor type");
                }

                _context.Measurements.Add(measurement);
              
                await _context.SaveChangesAsync();
            }


            return CreatedAtAction("GetMeasurements", null);
        }

        // DELETE: api/Measurements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Measurement>> DeleteMeasurement(long id)
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

        private bool MeasurementExists(long id)
        {
            return _context.Measurements.Any(e => e.MeasurementID == id);
        }
    }
}
