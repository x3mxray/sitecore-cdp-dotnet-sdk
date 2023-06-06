// <copyright file="CdpClient.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

using System;
using SitecoreCDP.SDK.Configuration;
using SitecoreCDP.SDK.Interfaces;
using SitecoreCDP.SDK.Services;

namespace SitecoreCDP.SDK
{
    public class CdpClient: ICdpClient
    {
        public ITenantApiService TenantApi { get; }
        public IAudienceSyncApiService AudienceSyncApi { get; }
        public IBatchApiService BatchApi { get; }
        public IInteractiveApiService InteractiveApi { get; }
        public IStreamApiService StreamApi { get; }

        public CdpClientConfig Config { get; set; }

        const string lastApiVersion = "v2";

        public CdpClient(CdpClientConfig cdpClientConfig)
        {
            Config = cdpClientConfig;
            TestConfig();
            AudienceSyncApi = new AudienceSyncApiService(cdpClientConfig);
            BatchApi = new BatchApiService(cdpClientConfig);
            InteractiveApi = new InteractiveApiService(cdpClientConfig);
            StreamApi = new StreamApiService(cdpClientConfig);
            TenantApi = new TenantApiService(cdpClientConfig);
        }

        void TestConfig()
        {
            if (string.IsNullOrEmpty(Config.BaseUrl))
                throw new ArgumentException("BaseUrl is null!", "CdpClientConfig.BaseUrl");
            if (string.IsNullOrEmpty(Config.ClientKey))
                throw new ArgumentException("ClientKey is null!", "CdpClientConfig.ClientKey");
            if (string.IsNullOrEmpty(Config.ApiToken))
                throw new ArgumentException("ApiToken is null!", "CdpClientConfig.ApiToken");
            if (string.IsNullOrEmpty(Config.Version))
                Config.Version = lastApiVersion;
        }
    }

}
