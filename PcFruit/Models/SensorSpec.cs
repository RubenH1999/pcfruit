using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class SensorSpec
    {
        public long SensorSpecID { get; set; }
        public long SensorID { get; set; }
        public Sensor Sensor { get; set; }
        public long SpecID { get; set; }
        public Spec Spec { get; set; }
    }
}
