// <copyright file="IInteractiveApiGuestService.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-5</date>

using System.Threading.Tasks;
using SitecoreCDP.SDK.Models.Interactive;

namespace SitecoreCDP.SDK.Interfaces
{
    /// <summary>
    /// Guest Data Extensions service
    /// </summary>
    internal interface IInteractiveApiGuestExtensionsService
    {
        /// <summary>
        /// Retrieves the guest record.
        /// </summary>
        /// <param name="guestRef">The reference of the guest record.</param>
        /// <param name="extName">Name of data extension. If extName='Test' request will come to /extTest/ path.</param>
        /// <returns></returns>
        Task<FindResponse> Find(string guestRef, string extName);

        Task<GuestDataExtension> Get(string guestRef, string extName, string extensionRef);
        Task<DataExtensionResponse> CreateOrUpdate<T>(string guestRef, string extName, T model);
    }
}
