// <copyright file="IInteractiveApiGuestService.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

using System.Threading.Tasks;
using SitecoreCDP.SDK.Models.Interactive;

namespace SitecoreCDP.SDK.Interfaces
{
    /// <summary>
    /// Guest service
    /// </summary>
    interface IInteractiveApiGuestService
    {
        /// <summary>
        /// Retrieves the guest record.
        /// </summary>
        /// <param name="guestRef">The reference of the guest record.</param>
        /// <returns></returns>
        Task<Guest> Get(string guestRef);
        /// <summary>
        /// Retrieve the full information about guest (including orders, events, etc.)
        /// </summary>
        /// <param name="guestRef">The reference of the guest record.</param>
        /// <returns></returns>
        Task<GuestContext> GetContext(string guestRef);
        /// <summary>
        /// Find guest by email and retrieve full information about guest (including orders, events, etc.)
        /// </summary>
        /// <param name="email">Guest email address</param>
        /// <returns></returns>
        Task<GuestContext> Find(string email);
        /// <summary>
        /// Creates a guest.
        /// </summary>
        /// <param name="guest">GuestCreate model</param>
        /// <returns></returns>
        Task<Guest> Create(GuestCreate guest);
        /// <summary>
        /// Updates the guest.
        /// </summary>
        /// <param name="guestRef">The reference of the guest record.</param>
        /// <param name="guest">GuestCreate model</param>
        /// <returns></returns>
        Task<Guest> Update(string guestRef, GuestCreate guest);
    }
}
