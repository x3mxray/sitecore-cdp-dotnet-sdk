using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SitecoreCDP.SDK.Models.Interactive
{
    public class GuestDataExtension
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("ref")]
        public string Ref { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("modifiedAt")]
        public DateTime ModifiedAt { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("values")]
        public Dictionary<string, dynamic> Values { get; set; }
    }
}
