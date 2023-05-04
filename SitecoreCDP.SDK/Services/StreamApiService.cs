using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Interfaces;
using SitecoreCDP.SDK.Models;

namespace SitecoreCDP.SDK.Services
{
    public class StreamApiService: BaseService, IStreamApiService
    {
        public string CreateNewSession()
        {
            throw new NotImplementedException();
        }

        public bool KillSession()
        {
            throw new NotImplementedException();
        }

        public void RunExperiment(string friendlyId)
        {
            throw new NotImplementedException();
        }

        public void TrackEvent(string eventName = "VIEW")
        {
            throw new NotImplementedException();
        }

        public void IdentifyUser(string provider, string identifier)
        {
            throw new NotImplementedException();
        }

        public StreamApiService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
        }
    }
}
