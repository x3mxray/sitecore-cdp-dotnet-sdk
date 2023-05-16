// <copyright file="IInteractiveApiGuestService.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

using System.Collections.Generic;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Models.Interactive;

namespace SitecoreCDP.SDK.Interfaces
{
    /// <summary>
    /// Guest service
    /// </summary>
    public interface IInteractiveApiGuestService
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
        /// Get guests by parameter (email, phoneNumber, firstName, lastName) and retrieve full information about guest.
        /// </summary>
        /// <param name="parameter">Guest parameter (field name).</param>
        /// <param name="value">Parameter value</param>
        /// <returns></returns>
        IAsyncEnumerable<GuestContext> FindByParameter(GuestParameter parameter, string value);
       
        /// <summary>
        /// Get first guest that matches parameter criteria (email, phoneNumber, firstName, lastName) and retrieve full information about guest.
        /// </summary>
        /// <param name="parameter">Guest parameter (field name).</param>
        /// <param name="value">Parameter value</param>
        Task<GuestContext> FindFirstByParameter(GuestParameter parameter, string value);

        /// <summary>
        /// Get guest by identifier.
        /// </summary>
        /// <param name="identityProvider">Identity provider name (field name).</param>
        /// <param name="identityValue">Identity value</param>
        Task<GuestContext> FindByIdentifier(string identityProvider, string identityValue);
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
