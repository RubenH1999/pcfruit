using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    /// <summary>
    /// Sensors are electronic components that are attached to a box
    /// </summary>
    public class Sensor
    {
        public int SensorID { get; set; }
        public SensorType Type {get; set;}

        public string Label { get; set; }
        public int Resistance { get; set; }
        public int Voltage { get; set; }
        public int Analog { get; set; }
        
        // thermo
        public int? Temperature { get; set; }
        public int? Humidity { get; set; }
        
        // dendro
        public int? Distance { get; set; }
    }
}
