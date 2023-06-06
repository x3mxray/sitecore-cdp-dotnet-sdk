using SitecoreCDP.SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Configuration;
using SitecoreCDP.SDK.Models.Tenant;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;

namespace SitecoreCDP.SDK.Services
{
    public class ConnectionsApiService : BaseService, IConnectionsApiService
    {
        public ConnectionsApiService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
        }

        public async Task<Connection> Get(string connectionRef)
        {
            var uri = new Uri(Endpoints.Tenant.Connections.Get(connectionRef));
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<Connection>(result);
        }

        public async Task<Connection> Create(Connection connection)
        {
            var uri = new Uri(Endpoints.Tenant.Connections.Create);
            var textContent = JsonSerializer.Serialize(connection);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpClient.PostAsync(uri, content);
            return await GetCdpResponse<Connection>(result);
        }

        public async Task<Connection> Update(Connection connection)
        {
            var uri = new Uri(Endpoints.Tenant.Connections.Get(connection.Ref));
            var textContent = JsonSerializer.Serialize(connection);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpClient.PostAsync(uri, content);
            return await GetCdpResponse<Connection>(result);
        }
    }
}
