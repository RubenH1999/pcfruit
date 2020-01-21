using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class Dendrometer
    {
        public int DendrometerID { get; set; }
        public string Label { get; set; }
        public int Analog { get; set; }
        public int Voltage { get; set; }
        public int Resistance { get; set; }
        public int Distance { get; set; }
    }
}
