using System;
using System.Collections.Generic;
using PcFruit.Models;

namespace PcFruit.Api.Responses
{
    public class MeasurementResponse
    {
        public string Name { get; set; }
        public DateTime TimeReceived { get; set; }
        public DateTime TimeRegistered { get; set; }
        public ICollection<SensorResponse> Sensors { get; set; }
    }
}