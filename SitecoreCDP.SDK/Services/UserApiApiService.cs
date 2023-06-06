using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Configuration;
using SitecoreCDP.SDK.Interfaces;
using SitecoreCDP.SDK.Models.Tenant;

namespace SitecoreCDP.SDK.Services
{
    public class UserApiService: BaseService, IUserApiService
    {
        public UserApiService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
        }

        public async Task<User> Get(string userRef)
        {
            var uri = new Uri(Endpoints.Tenant.Users.Get(userRef));
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<User>(result);
        }

        public async Task<UserFindResponse> GetAll(int limit=10, int offset=0)
        {
            var uri = new Uri(Endpoints.Tenant.Users.GetAll(limit, offset));
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<UserFindResponse>(result);
        }
    }
}
