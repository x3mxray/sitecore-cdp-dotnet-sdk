using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Models.Interactive;

namespace SitecoreCDP.SDK.Models.Tenant
{
    public class UserFindResponse : FindResponse
    {
        [JsonPropertyName("items")]
        public new List<User> Items { get; set; }
    }
    public class User
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("ref")]
        public string Ref { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastOrganisationKey")]
        public string LastOrganisationKey { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("lastSeen")]
        public DateTime LastSeen { get; set; }

        [JsonPropertyName("admin")]
        public bool Admin { get; set; }

        [JsonPropertyName("mfaActivated")]
        public bool MfaActivated { get; set; }

        [JsonPropertyName("roles")]
        public List<Role> Roles { get; set; }

        [JsonPropertyName("defaultOrganisationKey")]
        public string DefaultOrganisationKey { get; set; }
    }

    public class Role
    {
        [JsonPropertyName("ref")]
        public string Ref { get; set; }

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("modifiedAt")]
        public DateTime ModifiedAt { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rolePermissions")]
        public List<object> RolePermissions { get; set; }
    }
}
