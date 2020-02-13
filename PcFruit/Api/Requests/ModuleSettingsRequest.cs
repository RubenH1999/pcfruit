using PcFruit.Models;

namespace PcFruit.Api.Requests
{
    public class ModuleSettingsRequest
    {
        public string ModuleName { get; set; }
        public SensorType SensorType { get; set; }
        public short Min { get; set; }
        public short Max { get; set; }
    }
}