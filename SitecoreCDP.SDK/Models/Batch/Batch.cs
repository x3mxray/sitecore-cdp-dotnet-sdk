using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Batch
{
    public class Batch
    {
        [JsonPropertyName("ref")] public string ReferenceId { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("schema")]
        public string Schema { get; set; }

        [JsonPropertyName("mode")]
        public string Mode { get; set; }


    }
}
