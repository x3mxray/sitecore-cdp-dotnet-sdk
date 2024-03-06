using System;
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models
{
	public class Event
	{
		[JsonPropertyName("ref")]
		public string ReferenceId { get; set; }

		[JsonPropertyName("createdAt")]
		public DateTime CreatedAt { get; set; }

		[JsonPropertyName("modifiedAt")]
		public DateTime ModifiedAt { get; set; }

		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("channel")]
		public string Channel { get; set; }

		[JsonPropertyName("pointOfSale")]
		public string PointOfSale { get; set; }

		[JsonPropertyName("browserRef")]
		public string BrowserRef { get; set; }

		[JsonPropertyName("sessionRef")]
		public string SessionRef { get; set; }
	}
}
