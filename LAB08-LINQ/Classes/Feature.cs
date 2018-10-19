using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LAB08_LINQ.Classes
{
    public class Feature
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("geometry")]
        public Geometry geometry { get; set; }

        [JsonProperty("Properties")]
        public Properties properties { get; set; }
    }
}
