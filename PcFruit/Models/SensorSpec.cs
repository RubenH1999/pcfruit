using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class SensorSpec
    {
        // NOTE: primary key is a combined key of SensorID and specID (ASP.NET will do this automatically)
        public long SensorID { get; set; }
        public Sensor Sensor { get; set; }
        public long? SpecID { get; set; }
        public Spec Spec { get; set; }
    }
}
