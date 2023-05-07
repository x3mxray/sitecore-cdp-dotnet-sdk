using SitecoreCDP.SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Configuration;
using SitecoreCDP.SDK.Models.Interactive;

namespace SitecoreCDP.SDK.Services
{
    public class InteractiveApiGuestExtensionsService : BaseService, IInteractiveApiGuestExtensionsService
    {
        public InteractiveApiGuestExtensionsService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
        }

        public async Task<FindResponse> Find(string guestRef, string extName)
        {
            var uri = new Uri(Endpoints.Interactive.GuestExtensions.Find(guestRef, extName));
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<FindResponse>(result);
        }

        public async Task<GuestDataExtension> Get(string guestRef, string extName, string extensionRef)
        {
            var uri = new Uri(Endpoints.Interactive.GuestExtensions.Get(guestRef, extName, extensionRef));
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<GuestDataExtension>(result);
        }
    }
}
