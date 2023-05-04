// <copyright file="GuestCreate.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Interactive
{
    public class GuestCreate
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// The email addresses of the guest.
        /// </summary>
        [JsonPropertyName("emails")]
        public List<string> Emails { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("phoneNumbers")]
        public List<string> PhoneNumbers { get; set; }

        /// <summary>
        /// The level of identity obtained (lowercase).
        /// </summary>
        [JsonPropertyName("guestType")]
        public string GuestType { get; set; }

        /// <summary>
        /// The first name of the guest.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// The preferred language of the guest.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// The date of birth of the guest.
        /// </summary>
        [JsonPropertyName("dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// A list of identifiers for the guest.
        /// </summary>
        [JsonPropertyName("identifiers")]
        public List<Identifier> Identifiers { get; set; }


        //[JsonProperty("extext")]
        //public Hreference Extext { get; set; }

        //[JsonProperty("extExt")]
        //public Hreference ExtExt { get; set; }
    }
}
