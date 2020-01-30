using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class Spec
    {
        public long SpecID { get; set; }
        public string Name { get; set; } // temp, humidity, RH
        public double Min { get; set; } // e.g min temp
        public double Max { get; set; } // e.g max temp
        public ICollection<SensorSpec> SensorsSpecs { get; set; } // many to many relationship with sensors
    }
}
