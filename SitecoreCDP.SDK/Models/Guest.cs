// <copyright file="Guest.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models
{
    public class Guest
    {
        /// <summary>
        /// The first name of the guest.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the guest.
        /// </summary>
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// The gender of the guest (lowercase).
        /// </summary>
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// The preferred language of the guest.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }
        //[JsonPropertyName("street")]
        //public List<string> Street { get; set; }

        /// <summary>
        /// The guest's city.
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// The guest's state.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// The guest's country.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// The guest's postcode (uppercase).
        /// </summary>
        [JsonPropertyName("postCode")]
        public string PostCode { get; set; }

        /// <summary>
        /// The email address of the guest.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// The phone numbers of the guest.
        /// </summary>
        [JsonPropertyName("phoneNumbers")]
        public List<string> PhoneNumbers { get; set; }

        /// <summary>
        /// The first seen date for the guest.
        /// </summary>
        [JsonPropertyName("firstSeen")]
        public DateTime FirstSeen { get; set; }

        /// <summary>
        /// The last time the guest interacted with your brand. If the guest is currently online and is interacting with your brand, this returns the date and timestamp of when the current session started.
        /// </summary>
        [JsonPropertyName("lastSeen")]
        public DateTime LastSeen { get; set; }

        [JsonPropertyName("extensions")]
        public List<Extension> Extensions { get; set; }

        /// <summary>
        /// A list of identifiers for the guest.
        /// </summary>
        [JsonPropertyName("identifiers")]
        public List<Identifier> Identifiers { get; set; }
    }

    public class Extension
    {
        [JsonPropertyName("name")] public string Name { get; set; } = "ext";

        [JsonPropertyName("key")] public string Key { get; set; } = "default";
        [JsonPropertyName("loyaltyNumber")] public int LoyaltyNumber { get; set; } = (new Random()).Next(1000,9999);

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
