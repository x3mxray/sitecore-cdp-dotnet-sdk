// <copyright file="Batch.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Batch
{
    public class Batch
    {
        [JsonPropertyName("ref")] public string ReferenceId { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("schema")]
        public string Schema { get; set; }

        [JsonPropertyName("mode")]
        public string Mode { get; set; }


    }
}
