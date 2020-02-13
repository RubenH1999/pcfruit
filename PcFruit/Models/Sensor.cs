using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class Sensor
    {
        public long SensorID { get; set; }
        public string Name { get; set; }
        public SensorType SensorType { get; set; }
        public ICollection<SensorSpec> SensorSpecs { get; set; } // many to many relationship with sensors
    }
}
