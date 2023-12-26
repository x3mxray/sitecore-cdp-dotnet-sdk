using System.Collections.Generic;
using System.Text.Json.Serialization;
using SitecoreCDP.SDK.Models.Common;

namespace SitecoreCDP.SDK.Models.Interactive
{
	public class OrderContact : Models.Guest
	{

		[JsonPropertyName("emails")]
		public List<string> Emails { get; set; }
		[JsonPropertyName("guest")]
		public Hreference Guest { get; set; }
	}
}
