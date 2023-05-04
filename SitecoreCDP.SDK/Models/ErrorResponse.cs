// <copyright file="ErrorResponse.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models
{
    public class ErrorResponse
    {
        /// <summary>
        /// The corresponding HTTP status code.
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        /// <summary>
        /// An error code that can be used to obtain more information.
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// A simple, easy to understand message that you can show directly to your application end-user.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// A clear, plain-text explanation with technical details that assists a developer calling the APIs.
        /// </summary>
        [JsonPropertyName("developerMessage")]
        public string DeveloperMessage { get; set; }

        /// <summary>
        /// A fully qualified URL that might be accessed to obtain more information about the error.
        /// </summary>
        [JsonPropertyName("moreInfo")]
        public string MoreInfo { get; set; }

    }
}
