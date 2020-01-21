using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class Meter
    {
        public int MeterID { get; set; }
        public MeterType Type {get; set;}

        public string Label { get; internal set; }
        public int Resistance { get; set; }
        public int Volgtage { get; set; }
        public int Analog { get; set; }
        public int Voltage { get; internal set; }

        // thermo
        public int? Temperatuur { get; set; }
        public int? Vochtigheid { get; set; }
        
        // dendro
        public int? Distance { get; set; }
    }
}
