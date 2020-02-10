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

            if(context.Meters.Any() || context.Measurements.Any() || context.Modules.Any() || context.Users.Any())
            {
                return;
            }
 
            context.SaveChanges();
        }
    }
}
