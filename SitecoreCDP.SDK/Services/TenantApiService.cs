using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Configuration;
using SitecoreCDP.SDK.Interfaces;
using SitecoreCDP.SDK.Models;
using SitecoreCDP.SDK.Models.Tenant;

namespace SitecoreCDP.SDK.Services
{
    public class TenantApiService : BaseService, ITenantApiService
    {
        public ConnectionsApiService Connections { get; }
        public SegmentsApiService BatchSegments { get; }
        public UserApiService Users { get; }
        public TenantApiService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
            Connections = new ConnectionsApiService(cdpClientConfig);
            BatchSegments = new SegmentsApiService(cdpClientConfig);
            Users = new UserApiService(cdpClientConfig);
        }

        public async Task<TenantConfiguration> GetConfiguration()
        {
            var uri = new Uri(Endpoints.Tenant.Configuration);
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<TenantConfiguration>(result);
        }

        public async Task<TenantResponse> CreatePointOfSale(PointOfSale pos)
        {
            var uri = new Uri(Endpoints.Tenant.PointOfSale);
            var textContent = JsonSerializer.Serialize(pos);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpClient.PostAsync(uri, content);
            return await GetCdpResponse<TenantResponse>(result);
        }

        public async Task<TenantResponse> DeletePointOfSale(string name)
        {
            var uri = new Uri(Endpoints.Tenant.PointOfSaleDelete(name));
            var result = await _httpClient.DeleteAsync(uri);
            return await GetCdpResponse<TenantResponse>(result);
        }

        public async Task<List<PointOfSale>> GetPointOfSales()
        {
            var uri = new Uri(Endpoints.Tenant.PointOfSale);
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<List<PointOfSale>>(result);
        }

        public async Task<List<IdentityRules>> GetIdentityRules()
        {
            var uri = new Uri(Endpoints.Tenant.IdentityRules);
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<List<IdentityRules>>(result);
        }
    }
}
