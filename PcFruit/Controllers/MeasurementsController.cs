using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcFruit.Api.Requests;
using PcFruit.Api.Responses;
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
        public async Task<List<IGrouping<string,Measurement>>> GetMeasurements()
        {
            var measurementGroups = _context.Measurements
                .Include(m => m.Module)
                .Include(m => m.SensorSpec).ThenInclude(ss => ss.Sensor).GroupBy(m=>m.Module.Name).ToList();

            return measurementGroups;
        }

        

        // GET: api/Measurements/5
        /*[HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetMeasurement(long id)
        {
            var measurement = await _context.Measurements.FindAsync(id);

            if (measurement == null)
            {
                return NotFound();
            }

            return measurement;
        }*/

        // GET: api/Measurements/module
        [HttpGet("{module}")]
        public async Task<List<MeasurementResponse>> GetMeasurement(string module)
        {
            var measurementGroups =  _context.Measurements
                .Include(m => m.Module)
                .Where(m => m.Module.Name == module)
                .Include(m => m.SensorSpec).ThenInclude(ss => ss.Sensor)
                .GroupBy(m => m.TimeReceived);

            List<MeasurementResponse> measurements = new List<MeasurementResponse>();

            // iterate over each group (measurementGroups is an array of arrays, grouped by TimeReceived)
            foreach (var measurementGroup in measurementGroups)
            {
                // create singe object, which will contain all sensor data
                MeasurementResponse measurementResponse = new MeasurementResponse
                {
                    Module = measurementGroup.ElementAt(0).Module,
                    TimeReceived = measurementGroup.ElementAt(0).TimeReceived,
                    TimeRegistered = measurementGroup.ElementAt(0).TimeRegistered,
                    Sensors = measurementGroup.Select(m =>
                    {
                        SensorResponse s = new SensorResponse(m.SensorSpec.Sensor)
                        {
                            Value = m.Value
                        };
                        return s;
                    }).ToList()
                };

                measurements.Add(measurementResponse);
            }

            return measurements;
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
            foreach (SensorRequest sensorRequest in request.Sensors)
            {
                Measurement measurement = new Measurement
                {
                    Module = module,
                    TimeReceived = request.DateTime,
                    TimeRegistered = currentDate
                };
                // determine sensor type and set value of the measurement based on that
                switch (sensorRequest.GetType())
                {
                    case SensorType.Dendro:
                        measurement.Value = (double) sensorRequest.Distance;
                        break;
                    case SensorType.Humidity:
                        measurement.Value = (double) sensorRequest.Humidity;
                        break;
                    case SensorType.Thermo:
                        measurement.Value = (double) sensorRequest.Temperature;
                        break;
                    default:
                        throw new Exception("Unknown sensor type");
                }

                Sensor sensor = await _context.Sensors.FirstOrDefaultAsync(s => s.Name == sensorRequest.Label) ?? new Sensor
                {
                    Name = sensorRequest.Label,
                    SensorType = sensorRequest.GetType()
                };

                measurement.SensorSpec = new SensorSpec
                {
                    Sensor = sensor,
                    Spec = new Spec
                    {
                        Name = "test",
                        Max = 30,
                        Min = 0
                    }
                };
                
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
