using System;
using System.Collections.Generic;
using PcFruit.Models;

namespace PcFruit.Api.Responses
{
    public class NotificationResponse
    {
        public string ModuleName { get; set; }
        public List<SensorResponse> Sensors { get; set; }
    }
}