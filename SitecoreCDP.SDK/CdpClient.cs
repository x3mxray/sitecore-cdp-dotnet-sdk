using SitecoreCDP.SDK.Interfaces;
using SitecoreCDP.SDK.Models;
using SitecoreCDP.SDK.Services;

namespace SitecoreCDP.SDK
{
    public class CdpClient: ICdpClient
    {
        public IBatchApiService BatchApi { get; }
        public IInteractiveApiService InteractiveApi { get; }
        public IStreamApiService StreamApi { get; }
        public CdpClient(CdpClientConfig cdpClientConfig)
        {
            BatchApi = new BatchApiService(cdpClientConfig);
            InteractiveApi = new InteractiveApiService(cdpClientConfig);
            StreamApi = new StreamApiService(cdpClientConfig);
        }
    }

}
