using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PcFruit.Models;

namespace PcFruit.Controllers
{
    public abstract class BaseController
    {
        protected readonly PcfruitContext _context;
        
        protected BaseController(PcfruitContext context)
        {
            _context = context;
        }
    }
}
