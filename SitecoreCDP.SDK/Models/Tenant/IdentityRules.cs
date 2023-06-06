using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SitecoreCDP.SDK.Models.Tenant
{
    public class IdentityRules
    {
        [JsonPropertyName("identityRule")]
        public string IdentityRule { get; set; }

        [JsonPropertyName("providers")]
        public List<string> Providers { get; set; }
    }
}
