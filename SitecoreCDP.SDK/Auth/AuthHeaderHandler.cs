using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Configuration;

namespace SitecoreCDP.SDK.Auth
{
	public class AuthHeaderHandler : DelegatingHandler
	{
		public static string token = null;
		public static DateTime expiredDate = DateTime.MinValue;
		private readonly CdpAuthentification _credentials;
		private readonly AuthType _authType;

		public AuthHeaderHandler(CdpAuthentification credentials, AuthType authType=AuthType.ApiKey)
		{
			_credentials = credentials;
			_authType = authType;
			InnerHandler = new HttpClientHandler();
		}

		FormUrlEncodedContent GetAuthRequestByType()
		{
			var collection = new List<KeyValuePair<string, string>>();
			switch (_authType)
			{
				case AuthType.ApiKey:
					collection.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
					collection.Add(new KeyValuePair<string, string>("client_id", _credentials.ApiKey));
					collection.Add(new KeyValuePair<string, string>("client_secret", _credentials.ApiSecret));
					break;
				case AuthType.CloudUser:
					collection.Add(new KeyValuePair<string, string>("grant_type", "password"));
					collection.Add(new KeyValuePair<string, string>("username", _credentials.Username));
					collection.Add(new KeyValuePair<string, string>("password", _credentials.Password));
					break;
				default: throw new NotImplementedException("AuthType is undefined.");
			}
			return new FormUrlEncodedContent(collection);

		}

		Uri GetTokenUri()
		{
			switch (_authType)
			{
				case AuthType.ApiKey: return new Uri(_credentials.AuthUrl);
				case AuthType.CloudUser: return new Uri($"https://api-engage-eu.sitecorecloud.io/v2/oauth/token");
			}
			return new Uri(_credentials.AuthUrl);
		}

		async Task<string> GetToken()
		{
			if (expiredDate > DateTime.UtcNow && !string.IsNullOrEmpty(token))
				return token;

			var uri = GetTokenUri();
			var content = GetAuthRequestByType();

			var httpClient = new HttpClient();
			var result = await httpClient.PostAsync(uri, content);
			
			var response = await result.Content.ReadAsStringAsync();
			if (result.IsSuccessStatusCode)
			{

				var authResponse = JsonSerializer.Deserialize<AuthResponse>(response);
				token = authResponse.access_token;
				expiredDate = DateTime.UtcNow.AddSeconds(authResponse.expires_in - 1);
			}

			return token;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var bearerToken = await GetToken();

			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
			return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
		}
	}
}
