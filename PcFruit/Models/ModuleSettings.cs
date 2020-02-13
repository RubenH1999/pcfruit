namespace PcFruit.Models
{
    public class ModuleSettings
    {
        public long ModuleSettingsID { get; set; }
        public SensorType SensorType { get; set; }
        public long ModuleID { get; set; }
        public Module Module { get; set; }
        public short Min { get; set; }
        public short Max { get; set; }
    }
}