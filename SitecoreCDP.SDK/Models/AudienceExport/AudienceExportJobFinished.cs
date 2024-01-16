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
	public class AudienceExportJobFinished
	{
		[JsonPropertyName("executionRef")]
		public string ExecutionRef { get; set; }

		[JsonPropertyName("definitionRef")]
		public string DefinitionRef { get; set; }

		[JsonPropertyName("friendlyId")]
		public string FriendlyId { get; set; }

		[JsonPropertyName("definitionType")]
		public string DefinitionType { get; set; }

		[JsonPropertyName("clientKey")]
		public string ClientKey { get; set; }

		[JsonPropertyName("executionType")]
		public string ExecutionType { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("segmentExecutionType")]
		public string SegmentExecutionType { get; set; }

		[JsonPropertyName("total")]
		public int Total { get; set; }

		[JsonPropertyName("filterMatchedGuests")]
		public int FilterMatchedGuests { get; set; }

		[JsonPropertyName("filterNotMatchedGuests")]
		public int FilterNotMatchedGuests { get; set; }

		[JsonPropertyName("filterFailures")]
		public int FilterFailures { get; set; }

		[JsonPropertyName("successes")]
		public int Successes { get; set; }

		[JsonPropertyName("failures")]
		public int Failures { get; set; }

		[JsonPropertyName("startTime")]
		public DateTime StartTime { get; set; }

		[JsonPropertyName("endTime")]
		public DateTime EndTime { get; set; }

		[JsonPropertyName("datasetDate")]
		public string DatasetDate { get; set; }

		[JsonPropertyName("errorLogs")]
		public List<string> ErrorLogs { get; set; }

		[JsonPropertyName("filterErrors")]
		public List<ProgrammableError> FilterErrors { get; set; }

		[JsonPropertyName("programmableErrors")]
		public List<ProgrammableError> ProgrammableErrors { get; set; }
	}

	public class ProgrammableError
	{
		[JsonPropertyName("description")]
		public string Description { get; set; }

		[JsonPropertyName("count")]
		public int Count { get; set; }
	}
}
