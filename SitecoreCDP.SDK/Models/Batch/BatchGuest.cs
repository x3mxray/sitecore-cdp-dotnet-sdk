// <copyright file="BatchGuest.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Batch
{
    public class BatchGuest : Batch
    {
        public BatchGuest()
        {
            Schema = "guest";
            Mode = "upsert";
        }

        [JsonPropertyName("value")]
        public Guest Guest { get; set; }
    }
}
