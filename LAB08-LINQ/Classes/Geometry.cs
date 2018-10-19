using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LAB08_LINQ.Classes
{
    public class Geometry
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> coordinates { get; set; }
    }
}
