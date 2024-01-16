// <copyright file="IAudienceExportApiService.cs" company="Brimit">
// Copyright (c) 2024 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2024-1-16</date>

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.AudienceExport
{
	public class AudienceExportJob
	{
		[JsonPropertyName("audienceExportRef")]
		public string AudienceExportRef { get; set; }

		[JsonPropertyName("definitionRef")]
		public string DefinitionRef { get; set; }

		[JsonPropertyName("friendlyId")]
		public string FriendlyId { get; set; }

		[JsonPropertyName("clientKey")]
		public string ClientKey { get; set; }

		[JsonPropertyName("expireAt")]
		public DateTime ExpireAt { get; set; }

		[JsonPropertyName("numberOfFiles")]
		public int NumberOfFiles { get; set; }

		[JsonPropertyName("totalSizeKB")]
		public int TotalSizeKB { get; set; }

		[JsonPropertyName("exports")]
		public List<AudienceExportSignedUrl> Exports { get; set; }
	}

	public class AudienceExportSignedUrl
	{
		[JsonPropertyName("url")]
		public string Url { get; set; }
		[JsonPropertyName("sizeKB")]
		public int SizeKB { get; set; }
	}
}
