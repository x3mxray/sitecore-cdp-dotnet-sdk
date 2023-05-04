using SitecoreCDP.SDK.Models.Common;
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Interactive
{
    public class FindResponse
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("first")]
        public Hreference First { get; set; }

        [JsonPropertyName("last")]
        public Hreference Last { get; set; }
        [JsonPropertyName("items")]
        public List<Hreference> Items { get; set; }
    }
}
