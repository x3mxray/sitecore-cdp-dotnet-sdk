// <copyright file="ICdpClient.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>
namespace SitecoreCDP.SDK.Interfaces
{

    public interface ICdpClient
    {
        /// <summary>
        /// Interactive API (REST APIs)  is used to retrieve, create, update, and delete data that is available in Sitecore CDP.
        /// </summary>
        IInteractiveApiService InteractiveApi { get; }
        /// <summary>
        /// Batch API is used to upload guests, orders, and tracking events, which organizations can source in bulk from their internal systems before sending to Sitecore CDP for processing.
        /// </summary>
        IBatchApiService BatchApi { get; }
        /// <summary>
        /// The Stream API is used to send real-time behavioral and transactional data about the users of your application to Sitecore CDP.
        /// </summary>
        IStreamApiService StreamApi { get; }

        /// <summary>
        /// Tenant API is used to access to tenant entities, (like configuration, point-of-sales, connections, decisions etc.)
        /// </summary>
        ITenantApiService TenantApi { get; }

        public IAudienceSyncApiService AudienceSyncApi { get; }
    }
}
