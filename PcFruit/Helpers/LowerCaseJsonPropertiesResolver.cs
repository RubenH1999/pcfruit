using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace PcFruit.Helpers
{
    public class LowerCaseJsonPropertiesResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName) => Char.ToLowerInvariant(propertyName[0]) + propertyName.Substring(1);
    }
}
