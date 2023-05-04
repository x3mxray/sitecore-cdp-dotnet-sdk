using SitecoreCDP.SDK.Models.Common;
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Interactive
{
    public class OrderItem
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("ref")]
        public string Ref { get; set; }

        [JsonPropertyName("order")]
        public Hreference Order { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("modifiedAt")]
        public DateTime ModifiedAt { get; set; }

        [JsonPropertyName("orderedAt")]
        public DateTime OrderedAt { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("channel")]
        public string Channel { get; set; }
    }
}
