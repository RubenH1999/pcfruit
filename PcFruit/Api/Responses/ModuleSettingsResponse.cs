using System.Collections.Generic;
using PcFruit.Models;

namespace PcFruit.Api.Responses
{
    public class ModuleSettingsResponse
    {
        public List<ModuleSettings> ModuleSettings { get; set; }
        public List<string> AvailableSensorTypes { get; set; }
    }
}