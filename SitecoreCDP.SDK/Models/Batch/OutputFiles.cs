using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Batch
{
    public class OutputFilesResponse
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
        [JsonPropertyName("ref")]
        public string Ref { get; set; }
        [JsonPropertyName("flowRef")]
        public string FlowRef { get; set; }
        [JsonPropertyName("segmentRef")]
        public string SegmentRef { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("signedUrls")]
        public List<string> SignedUrls { get; set; }
    }
}
