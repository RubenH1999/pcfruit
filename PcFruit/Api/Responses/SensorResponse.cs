using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Storage;
using PcFruit.Models;

namespace PcFruit.Api.Responses
{
    public class SensorResponse : Sensor
    {
        public double Value { get; set; }
        public DateTime TimeRegistered { get; set; }
        public short Min { get; set; }
        public short Max { get; set; }

        public SensorResponse(Sensor sensor) : base()
        {
            // automatically populate fields based on given parent class
            foreach (FieldInfo prop in sensor.GetType().GetFields())
                GetType().GetField(prop.Name).SetValue(this, prop.GetValue(sensor));

            foreach (PropertyInfo prop in sensor.GetType().GetProperties())
                GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(sensor, null), null);
        } 
    }
}