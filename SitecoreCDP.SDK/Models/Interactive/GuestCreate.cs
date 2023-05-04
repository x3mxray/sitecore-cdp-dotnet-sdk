﻿using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Interactive
{
    public class GuestCreate
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("emails")]
        public List<string> Emails { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("phoneNumbers")]
        public List<string> PhoneNumbers { get; set; }

        [JsonPropertyName("guestType")]
        public string GuestType { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        [JsonPropertyName("identifiers")]
        public List<Identifier> Identifiers { get; set; }


        //[JsonProperty("extext")]
        //public Hreference Extext { get; set; }

        //[JsonProperty("extExt")]
        //public Hreference ExtExt { get; set; }
    }
}
