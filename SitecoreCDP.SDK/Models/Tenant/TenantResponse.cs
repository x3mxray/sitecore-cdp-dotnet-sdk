using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SitecoreCDP.SDK.Models.Tenant
{
    public class TenantResponse
    {
        [JsonPropertyName("request")]
        public string Request { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("result")]
        public string Result { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("developerMessage")]
        public string DeveloperMessage { get; set; }
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("code")]
        public int Code { get; set; }
    }
}
