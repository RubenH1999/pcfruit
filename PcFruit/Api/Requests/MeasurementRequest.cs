using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PcFruit.Models;

namespace PcFruit.Api.Requests
{
    public class MeasurementRequest
    {
        public string Logger { get; set; }
        public DateTime DateTime { get; set; }
        public List<Sensor> Dendrometers { get; set; }
        public List<Sensor> Thermometers { get; set; }
    }
}
