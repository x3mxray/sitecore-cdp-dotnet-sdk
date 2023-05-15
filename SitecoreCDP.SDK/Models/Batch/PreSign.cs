// <copyright file="RestModels.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>
using SitecoreCDP.SDK.Models.Common;
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Batch
{
    public class PreSignRequest
    {
        public string checksum { get; set; }
        public long size { get; set; }
    }
    public class PreSignResponse
    {
        [JsonPropertyName("location")]
        public Hreference Location { get; set; }
    }
}
