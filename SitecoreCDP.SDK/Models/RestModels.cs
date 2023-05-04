using SitecoreCDP.SDK.Models.Common;

namespace SitecoreCDP.SDK.Models
{
    public class PreSignRequest
    {
        public string checksum { get; set; }
        public long size { get; set; }
    }
    public class PreSignResponse
    {
        public Hreference Location { get; set; }
    }
}
