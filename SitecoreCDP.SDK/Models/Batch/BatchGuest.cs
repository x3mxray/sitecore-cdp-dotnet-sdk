using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Batch
{
    public class BatchGuest : Batch
    {
        public BatchGuest()
        {
            Schema = "guest";
            Mode = "upsert";
        }

        [JsonPropertyName("value")]
        public Guest Guest { get; set; }
    }
}
