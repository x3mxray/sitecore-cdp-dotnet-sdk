using System.Text.Json;
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models
{
    public class ErrorResponse
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("developerMessage")]
        public string DeveloperMessage { get; set; }

        [JsonPropertyName("moreInfo")]
        public string MoreInfo { get; set; }

    }
}
