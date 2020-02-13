using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PcFruit.Models;

namespace PcFruit.Api.Requests
{
    public class SensorRequest
    {
        public string Label { get; set; }
        public double Analog { get; set; }
        public double Voltage { get; set; }
        public double Resistance { get; set; }
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
        public double? Distance { get; set; }

        public SensorType GetType()
        {
            if (Distance != null) return SensorType.Dendro;
            if (Temperature != null) return SensorType.Thermo;
            if (Humidity != null) return SensorType.Humidity;

            return SensorType.Unknown;
        }
    }
}