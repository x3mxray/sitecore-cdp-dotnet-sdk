﻿using System.Net.Http.Headers;
using System.Net;
using System.Text;
using SitecoreCDP.SDK.Models;
using System.Text.Json;
using SitecoreCDP.SDK.Configuration;

namespace SitecoreCDP.SDK.Services
{
    public class BaseService
    {
        private readonly CdpClientConfig _cdpClientConfig;
        public HttpClient _httpClient => new() { DefaultRequestHeaders = { Authorization = AuthHeader } };
        public AuthenticationHeaderValue AuthHeader
        {
            get
            {
                var authenticationString = $"{_cdpClientConfig.ClientKey}:{_cdpClientConfig.ApiToken}";
                var base64EncodedAuthenticationString = Convert.ToBase64String(Encoding.ASCII.GetBytes(authenticationString));
                return new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
            }
        }
        public BaseService(CdpClientConfig cdpClientConfig)
        {
            _cdpClientConfig = cdpClientConfig;
            Endpoints.ApiEndpoint = _cdpClientConfig.ApiEndpoint;
            Endpoints.Version = _cdpClientConfig.Version;
        }

        ErrorResponse GetErrorResponse(string response)
        {
            return JsonSerializer.Deserialize<ErrorResponse>(response);
        }

        public HttpRequestException CdpException(string response)
        {
            var error = JsonSerializer.Deserialize<ErrorResponse>(response);
            return new HttpRequestException(error.Message, new Exception(error.DeveloperMessage), (HttpStatusCode)error.Status);
        }

        public async Task<TValue> GetCdpResponse<TValue>(HttpResponseMessage result)
        {
            var response = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {

                return JsonSerializer.Deserialize<TValue>(response);
            }

            throw CdpException(response);
        }
    }
}
