using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Models.Tenant;

namespace SitecoreCDP.SDK.Interfaces
{
    public interface ISegmentsApiService
    {
        Task<Segment> Get(string segmentRefOrfriendlyName);
        Task<List<Segment>> GetAll();
    }
}
