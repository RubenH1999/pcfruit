using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcFruit.Api.Requests;
using PcFruit.Api.Responses;
using PcFruit.Models;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace PcFruit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly PcfruitContext _context;

        public ModulesController(PcfruitContext context)
        {
            _context = context;
        }

        // GET: api/Modules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Module>>> GetModules()
        {
            return await _context.Modules.ToListAsync();
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Module>> GetModule(long id)
        {
            var @module = await _context.Modules.FindAsync(id);

            if (@module == null)
            {
                return NotFound();
            }

            return @module;
        }

        // GET: api/Modules/5/notifications
        [HttpGet("{name}/notifications")]
        public async Task<ActionResult<NotificationResponse>> GetModuleNotifications(string name)
        {
            // find the module and include all data we need
            var module = await _context.Modules
                .Include(m => m.ModuleSettings)
                .Include(m => m.Measurements)
                    .ThenInclude(mes => mes.SensorSpec)
                        .ThenInclude(ss => ss.Sensor)
                .FirstOrDefaultAsync(m => m.Name == name);

            if (module == null) return NotFound();
            
            // get all measurements that exceeded the maximum or are lower that the minimum that was specified in ModuleSettings.
            var problematicMeasurements = module.ModuleSettings.SelectMany(ms =>
            {
                return module.Measurements
                    .Where(m => m.SensorSpec.Sensor.SensorType == ms.SensorType)
                    .Where(m => m.Value > ms.Max || m.Value < ms.Min);
            }).ToList();

            if (problematicMeasurements.Count == 0)
                return Ok(problematicMeasurements);

            // (this only includes the most recent notifications)
            var latestProblematicMeasurements = problematicMeasurements
                .GroupBy(m => m.TimeRegistered)
                .First();

            return new NotificationResponse
            {
                ModuleName = module.Name,
                Sensors = latestProblematicMeasurements
                    .Select(m => new SensorResponse(m.SensorSpec.Sensor)
                    {
                        Value = m.Value,
                        TimeRegistered = m.TimeRegistered,
                        Min = module.ModuleSettings.First(mod => mod.SensorType == m.SensorSpec.Sensor.SensorType).Min,
                        Max = module.ModuleSettings.First(mod => mod.SensorType == m.SensorSpec.Sensor.SensorType).Max,

                    })
                    .ToList()
            };
        }

        [HttpGet("{name}/settings")]
        public async Task<ModuleSettingsResponse> GetModuleSettings(string name)
        {
            var sensorTypes = Enum.GetValues(typeof(SensorType))
                .Cast<SensorType>()
                .Select(i => Enum.GetName(typeof(SensorType), i))
                .ToList();

            return new ModuleSettingsResponse
            {
                AvailableSensorTypes = sensorTypes,
                ModuleSettings = _context.ModuleSettings
                    .Include(m => m.Module)
                    .Where(m => m.Module.Name == name)
                    .ToList()
            };
        }

        // PUT: api/Modules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(long id, Module @module)
        {
            if (id != @module.ModuleID)
            {
                return BadRequest();
            }

            _context.Entry(@module).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
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

        // POST: api/Modules
        [HttpPost]
        public async Task<ActionResult<Module>> PostModule(Module @module)
        {
            _context.Modules.Add(@module);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModule", new { id = @module.ModuleID }, @module);
        }


        // POST: api/Modules
        [HttpPost("settings")]
        public async Task<ActionResult<Module>> PostModuleSettings(ModuleSettingsRequest request)
        {

            Module module = _context.Modules
                .Include(m => m.ModuleSettings)
                .FirstOrDefault(m => m.Name == request.ModuleName);

            if (module == null)
                return BadRequest("Module " + request.ModuleName + " does not exist!");

            ModuleSettings moduleSettings = module.ModuleSettings.FirstOrDefault(ms => ms.SensorType == request.SensorType);

            // if given sensor type already has a setting, update the module settings instead
            if (moduleSettings != null)
            {
                moduleSettings.Min = request.Min;
                moduleSettings.Max = request.Max;
                _context.Entry(module).State = EntityState.Modified;
            }
            else
            {
                moduleSettings = new ModuleSettings
                {
                    Min = request.Min,
                    Max = request.Max,
                    Module = module,
                    SensorType = request.SensorType
                };
                _context.ModuleSettings.Add(moduleSettings);
            }
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModule", new { id = module.ModuleID }, @module);
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Module>> DeleteModule(long id)
        {
            var @module = await _context.Modules.FindAsync(id);
            if (@module == null)
            {
                return NotFound();
            }

            _context.Modules.Remove(@module);
            await _context.SaveChangesAsync();

            return @module;
        }

        private bool ModuleExists(long id)
        {
            return _context.Modules.Any(e => e.ModuleID == id);
        }
    }
}
