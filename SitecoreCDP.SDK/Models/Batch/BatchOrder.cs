using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Batch
{
    public class BatchOrder : Batch
    {
        public BatchOrder()
        {
            Schema = "order";
            Mode = "insert";
        }

        [JsonPropertyName("value")]
        public Order Order { get; set; }
    }
}
