using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    /// <summary>
    /// A module receives data from multiple sensors
    /// </summary>
    public class Module
    {
        public int ModuleID { get; set; }
        public string Name { get; set; }
        public List<Measurement> Measurements { get; set; }
    }
}
