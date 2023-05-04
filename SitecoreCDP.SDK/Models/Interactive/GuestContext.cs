using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Interactive
{
    public class GuestContext : Guest
    {
        [JsonPropertyName("orders")]
        public List<OrderContext> Orders { get; set; }
    }

    public class OrderContext : Order
    {
        [JsonPropertyName("orderItems")]
        public List<OrderItemContext> OrderItems { get; set; }
    }

    public class OrderItemContext : OrderItem
    {
        [JsonPropertyName("referenceId")]
        public string ReferenceId { get; set; }
        [JsonPropertyName("itemId")]
        public string ItemId { get; set; }
    }
}
