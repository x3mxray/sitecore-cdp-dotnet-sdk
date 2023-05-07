// <copyright file="Guest.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Interactive
{
    public class Guest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("emails")]
        public List<string> Emails { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("phoneNumbers")]
        public List<string> PhoneNumbers { get; set; }

        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("ref")]
        public string Ref { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("modifiedAt")]
        public DateTime ModifiedAt { get; set; }

        [JsonPropertyName("firstSeen")]
        public DateTime FirstSeen { get; set; }

        [JsonPropertyName("lastSeen")]
        public DateTime LastSeen { get; set; }

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

        [JsonPropertyName("identifiers")]
        public List<Identifier> Identifiers { get; set; }

        [JsonPropertyName("identityStatus")]
        public string IdentityStatus { get; set; }

        //[JsonProperty("extext")]
        //public Hreference Extext { get; set; }

        //[JsonProperty("extExt")]
        //public Hreference ExtExt { get; set; }
    }
}
