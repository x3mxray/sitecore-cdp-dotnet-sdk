using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Batch
{
    public class BatchLog
    {
        [JsonPropertyName("ref")]
        public string Ref { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
