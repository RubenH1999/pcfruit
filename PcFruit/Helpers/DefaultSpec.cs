using System;
using PcFruit.Models;

namespace PcFruit.Helpers
{
    public class DefaultSpec : Spec
    {
        public DefaultSpec(SensorType sensorType)
        {
            switch (sensorType)
            {
                case SensorType.Dendro:
                    Name = "dendro";
                    Min = 0;
                    Max = 15;
                    break;
                case SensorType.Thermo:
                    Name = "thermo";
                    Min = -5;
                    Max = 40;
                    break;
                case SensorType.Humidity:
                    Name = "vocht";
                    Min = 80;
                    Max = 100;
                    break;
                case SensorType.Unknown:
                default:
                    Name = "default";
                    Min = 0;
                    Max = 20;
                    break;
            }
        }
    }
}