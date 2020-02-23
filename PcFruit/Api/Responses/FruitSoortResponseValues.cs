using System;
using System.Collections.Generic;
using PcFruit.Models;

namespace PcFruit.Api.Responses
{
    public class FruitSoortResponseValues
    {
        public DateTime TimeRegistered { get; set; }
        public List<double> Values { get; set; }
        
    }
}