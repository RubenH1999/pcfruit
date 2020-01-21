using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class Thermometer
    {
        public int ThermometerID { get; set; }
        public int Temperatuur { get; set; }
        public int Vochtigheid { get; set; }
        public int Resistance { get; set; }
        public int Volgtage { get; set; }
        public int Analog { get; set; }

    }
}
