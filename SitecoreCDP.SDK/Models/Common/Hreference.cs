using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Common
{
    public class Hreference
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
