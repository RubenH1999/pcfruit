using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class DBInitializer
    {
        public static void Initialize(PcfruitContext context)
        {
            context.Database.EnsureCreated();

            if(context.Meters.Any())
            {
                return;
            }

            context.Meters.AddRange(
                new Meter { Analog = 0, Distance = 1, Label = "L", Resistance = 0, Voltage = 0 }
            );
           
            context.SaveChanges();
        }
    }
}
