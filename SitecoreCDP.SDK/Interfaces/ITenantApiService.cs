using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Models;
using SitecoreCDP.SDK.Models.Tenant;
using SitecoreCDP.SDK.Services;

namespace SitecoreCDP.SDK.Interfaces
{
    public interface ITenantApiService
    {
        /// <summary>
        /// Get tenant settings and configurations.
        /// </summary>
        /// <returns></returns>
        public Task<TenantConfiguration> GetConfiguration();

        /// <summary>
        /// Get tenant point of sales list
        /// </summary>
        /// <returns></returns>
        Task<List<PointOfSale>> GetPointOfSales();

        /// <summary>
        /// Get tenant Identity rules
        /// </summary>
        /// <returns></returns>
        Task<List<IdentityRules>> GetIdentityRules();
        /// <summary>
        /// Connections service
        /// </summary>
        public ConnectionsApiService Connections { get; }
        /// <summary>
        /// Batch segments service
        /// </summary>
        public SegmentsApiService BatchSegments { get; }
        /// <summary>
        /// Tenant users service
        /// </summary>
        public UserApiService Users { get; }

        Task<TenantResponse> CreatePointOfSale(PointOfSale pos);
    }
}
