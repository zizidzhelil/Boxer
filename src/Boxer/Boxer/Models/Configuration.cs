using Newtonsoft.Json;
using System.Collections.Generic;

namespace Boxer.Models
{
    public class Configuration
    {
        [JsonProperty("values")]
        public List<string> Values { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
