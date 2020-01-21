using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class Measurement
    {
        public int MeasurementID { get; set; }
        public int ModuleID { get; set; }
        public Module Module { get; set; }
        // dateTime when registered at API
        public DateTime TimeReceived { get; set; }
        // dateTime when registered at module
        public DateTime TimeRegistered { get; set; }
        public List<Sensor> Sensors { get; set; }
    }
}
