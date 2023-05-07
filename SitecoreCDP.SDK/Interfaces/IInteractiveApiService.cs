// <copyright file="IInteractiveApiService.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>
using SitecoreCDP.SDK.Services;

namespace SitecoreCDP.SDK.Interfaces
{
    /// <summary>
    /// REST Api service
    /// </summary>
    public interface IInteractiveApiService
    {
        /// <summary>
        ///  Guests service
        /// </summary>
        public InteractiveApiGuestService Guests { get; }

        /// <summary>
        /// Guest Data Extensions service
        /// </summary>
        public InteractiveApiGuestExtensionsService GuestExtensions { get; }
        /// <summary>
        /// Orders service
        /// </summary>
        public InteractiveApiOrderService Orders { get; }
        /// <summary>
        /// OrderItems service
        /// </summary>
        public InteractiveApiOrderItemService OrderItems { get; }
    }
}
