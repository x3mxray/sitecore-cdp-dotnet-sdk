// <copyright file="BaseService.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

using System;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http;
using System.Text;
using SitecoreCDP.SDK.Models;
using System.Text.Json;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Configuration;

namespace SitecoreCDP.SDK.Services
{
    public class BaseService
    {
        private readonly CdpClientConfig _cdpClientConfig;
        public HttpClient _httpClient => new HttpClient() { DefaultRequestHeaders = { Authorization = AuthHeader} };
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
            Endpoints.BaseUrl = _cdpClientConfig.BaseUrl;
            Endpoints.Version = _cdpClientConfig.Version;
        }

        ErrorResponse GetErrorResponse(string response)
        {
            return JsonSerializer.Deserialize<ErrorResponse>(response);
        }

        public HttpRequestException CdpException(string response)
        {
            var error = JsonSerializer.Deserialize<ErrorResponse>(response);
            return new HttpRequestException(error.Message, new Exception(error.DeveloperMessage));
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
