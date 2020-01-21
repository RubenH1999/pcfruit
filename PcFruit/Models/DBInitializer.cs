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

            if(context.Dendrometers.Any())
            {
                return;
            }
            
            context.Dendrometers.AddRange(
                new Dendrometer { Analog = 0, Distance = 1, Label = "L", Resistance = 0, Voltage = 0 },
                new Dendrometer { Analog = 0, Distance = 1, Label = "L", Resistance = 0, Voltage = 0 }
                );
            context.Thermometers.AddRange(
                new Thermometer { Analog = 0, Resistance = 1 , Temperatuur= 14, Vochtigheid = 0, Volgtage=0},
                new Thermometer { Analog = 1, Resistance = 2, Temperatuur = 10, Vochtigheid = 0, Volgtage = 0 }
                );
           
            context.SaveChanges();
        }
    }
}
