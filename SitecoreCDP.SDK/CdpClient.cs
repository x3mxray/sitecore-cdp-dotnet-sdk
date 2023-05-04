// <copyright file="CdpClient.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>
using SitecoreCDP.SDK.Configuration;
using SitecoreCDP.SDK.Interfaces;
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
