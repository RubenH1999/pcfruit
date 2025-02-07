﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class Measurement
    {
        public long MeasurementID { get; set; }
        public long ModuleID { get; set; }
        public Module Module { get; set; }
        public long SensorSpecID { get; set; }
        public SensorSpec SensorSpec { get; set; }
        public double Value { get; set; } // the actual measurement value e.g. 8.32 (cm)
        public DateTime TimeRegistered { get; set; } // time registered by server / API
        public DateTime TimeReceived { get; set; } // time registered by the module
    }
}
