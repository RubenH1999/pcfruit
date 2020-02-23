using System;
using System.Collections.Generic;
using PcFruit.Models;

namespace PcFruit.Api.Responses
{
    public class FruitSoortResponseList
    {
        public List<FruitSoortResponse> ListAppels { get; set; }
        public List<FruitSoortResponse> ListPeren { get; set; }
    }
}