using SitecoreCDP.SDK.Models.Common;
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Interactive
{
    public class Order
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("ref")]
        public string Ref { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("modifiedAt")]
        public DateTime ModifiedAt { get; set; }

        [JsonPropertyName("orderedAt")]
        public DateTime OrderedAt { get; set; }

        [JsonPropertyName("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("paymentType")]
        public string PaymentType { get; set; }

        [JsonPropertyName("pointOfSale")]
        public string PointOfSale { get; set; }

        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("contacts")]
        public Hreference Contacts { get; set; }

        [JsonPropertyName("consumers")]
        public Hreference Consumers { get; set; }

        [JsonPropertyName("orderItems")]
        public Hreference OrderItems { get; set; }
    }
}
