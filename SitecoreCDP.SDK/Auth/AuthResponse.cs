using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCDP.SDK.Auth
{
	public class AuthResponse
	{
		public string access_token { get; set; }
		public int expires_in { get; set; }
	}
}
