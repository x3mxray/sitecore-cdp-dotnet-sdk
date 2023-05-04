// <copyright file="BatchUploadResponse.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Batch
{
    public class BatchUploadResponse
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("ref")]
        public string Ref { get; set; }

        [JsonPropertyName("checksum")]
        public string Checksum { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("location")]
        public BatchLocation Location { get; set; }

        [JsonPropertyName("status")]
        public BatchStatus Status { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("modifiedAt")]
        public DateTime ModifiedAt { get; set; }
    }

    public class BatchStatus
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("log")]
        public string LogUri { get; set; }
    }

    public class BatchLocation
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("expiry")]
        public DateTime Expiry { get; set; }
    }
}
