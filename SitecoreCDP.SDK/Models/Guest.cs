using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models
{
    public class Guest
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        //[JsonPropertyName("street")]
        //public List<string> Street { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("postCode")]
        public string PostCode { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("phoneNumbers")]
        public List<string> PhoneNumbers { get; set; }


        [JsonPropertyName("firstSeen")]
        public DateTime FirstSeen { get; set; }

        [JsonPropertyName("lastSeen")]
        public DateTime LastSeen { get; set; }

        [JsonPropertyName("extensions")]
        public List<Extension> Extensions { get; set; }

        [JsonPropertyName("identifiers")]
        public List<Identifier> Identifiers { get; set; }
    }

    public class Extension
    {
        [JsonPropertyName("name")] public string Name { get; set; } = "ext";

        [JsonPropertyName("key")] public string Key { get; set; } = "default";

        //[JsonPropertyName("testUser")] public bool TestUser { get; set; } = true;
    }

    public class Identifier
    {
        [JsonPropertyName("provider")]
        public string Provider { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
