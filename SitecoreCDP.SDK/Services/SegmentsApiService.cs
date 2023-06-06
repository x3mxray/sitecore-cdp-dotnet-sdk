using SitecoreCDP.SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Configuration;
using SitecoreCDP.SDK.Models.Tenant;

namespace SitecoreCDP.SDK.Services
{
    public class SegmentsApiService : BaseService, ISegmentsApiService
    {
        public SegmentsApiService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
        }

        public async Task<Segment> Get(string segmentRefOrfriendlyName)
        {
            var uri = new Uri(Endpoints.Tenant.Segments.Get(segmentRefOrfriendlyName));
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<Segment>(result);
        }

        public async Task<List<Segment>> GetAll()
        {
            var uri = new Uri(Endpoints.Tenant.Segments.GetAll);
            var result = await _httpClient.GetAsync(uri);
            var segmentResponse = await GetCdpResponse<SegmentList>(result);
            return segmentResponse.Segments;
        }
    }
}
