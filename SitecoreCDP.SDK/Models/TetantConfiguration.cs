using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SitecoreCDP.SDK.Models
{
    public class TenantConfiguration
    {
        [JsonPropertyName("settings")]
        public TenantSettings Settings { get; set; }

        [JsonPropertyName("configurations")]
        public TenantConfigurations Configurations { get; set; }
    }

    public class TenantConfigurations
    {
        [JsonPropertyName("cookieDomain")]
        public string CookieDomain { get; set; }

        [JsonPropertyName("dateFormat")]
        public string DateFormat { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
    public class TenantSettings
    {
        [JsonPropertyName("defaultTimeout")]
        public int DefaultTimeout { get; set; }

        [JsonPropertyName("segmentationVersion")]
        public string SegmentationVersion { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("guestContextVersion")]
        public string GuestContextVersion { get; set; }

        [JsonPropertyName("active")]
        public string Active { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("schemaName")]
        public string SchemaName { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("webExperiences")]
        public string WebExperiences { get; set; }

        [JsonPropertyName("productCode")]
        public string ProductCode { get; set; }

        [JsonPropertyName("productLicence")]
        public string ProductLicence { get; set; }

        [JsonPropertyName("clientKey")]
        public string ClientKey { get; set; }

        [JsonPropertyName("updated")]
        public DateTime Updated { get; set; }
    }
}
