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
        /// Retrieves the guest extension record.
        /// </summary>
        /// <param name="guestRef">The reference of the guest record.</param>
        /// <param name="extName">Name of data extension. If extName='Test' request will come to /extTest/ path.</param>
        /// <returns></returns>
        Task<FindResponse> Get(string guestRef, string extName);
        /// <summary>
        /// Retrieves guest extension item.
        /// </summary>
        /// <param name="guestRef">The reference of the guest record.</param>
        /// <param name="extName">Name of data extension. If extName='Test' request will come to /extTest/ path.</param>
        /// <param name="extensionRef">Reference of extension item.</param>
        /// <returns></returns>
        Task<GuestDataExtension> Get(string guestRef, string extName, string extensionRef);
        /// <summary>
        /// Retrieves guest extension item.
        /// </summary>
        /// <param name="guestRef">The reference of the guest record.</param>
        /// <param name="extName">Name of data extension. If extName='Test' request will come to /extTest/ path.</param>
        /// <param name="model">Custom extension item.</param>
        /// <returns></returns>
        Task<DataExtensionResponse> CreateOrUpdate<T>(string guestRef, string extName, T model);

        /// <summary>
        /// Delete guest extension by name.
        /// </summary>
        /// <param name="guestRef">The reference of the guest record.</param>
        /// <param name="extName">Name of data extension. If extName='Test' request will come to /extTest/ path.</param>
        /// <returns></returns>
        Task Delete(string guestRef, string extName);
    }
}
