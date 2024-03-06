using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models
{
	public class Session
	{
		[JsonPropertyName("ref")]
		public string ReferenceId { get; set; }
		[JsonPropertyName("createdAt")]
		public DateTime CreatedAt { get; set; }

		[JsonPropertyName("modifiedAt")]
		public DateTime ModifiedAt { get; set; }

		[JsonPropertyName("guestRef")]
		public string GuestRef { get; set; }

		[JsonPropertyName("browserRef")]
		public string BrowserRef { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("sessionType")]
		public string SessionType { get; set; }

		[JsonPropertyName("cartType")]
		public string CartType { get; set; }

		[JsonPropertyName("startedAt")]
		public DateTime StartedAt { get; set; }

		[JsonPropertyName("endedAt")]
		public DateTime EndedAt { get; set; }

		[JsonPropertyName("duration")]
		public long Duration { get; set; }

		[JsonPropertyName("pointOfSale")]
		public string PointOfSale { get; set; }

		[JsonPropertyName("channel")]
		public string Channel { get; set; }

		[JsonPropertyName("referer")]
		public string Referer { get; set; }

		[JsonPropertyName("operatingSystem")]
		public string OperatingSystem { get; set; }

		[JsonPropertyName("userAgent")]
		public string UserAgent { get; set; }

		[JsonPropertyName("language")]
		public string Language { get; set; }

		[JsonPropertyName("firstPageURI")]
		public string FirstPageURI { get; set; }

		[JsonPropertyName("lastPageURI")]
		public string LastPageURI { get; set; }

		[JsonPropertyName("events")]
		public List<Event> Events { get; set; }
	}
}
