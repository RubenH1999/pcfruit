using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class Module
    {
        public long ModuleID { get; set; }
        public string Name { get; set; }
        public ICollection<Measurement> Measurements { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
