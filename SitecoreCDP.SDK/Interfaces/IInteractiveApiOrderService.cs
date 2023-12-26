// <copyright file="IInteractiveApiOrderService.cs" company="Brimit">
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
    /// Orders service
    /// </summary>
    interface IInteractiveApiOrderService
    {
        /// <summary>
        /// Retrieves a list of orders. 
        /// </summary>
        /// <param name="guestRef">The reference of the guest record.</param>
        /// <returns></returns>
        IAsyncEnumerable<Order> Find(string guestRef);
        /// <summary>
        /// Get the order reference
        /// </summary>
        /// <param name="orderRef">The reference of the order.</param>
        /// <returns></returns>
        Task<Order> Get(string orderRef);

        Task<Order> Create(string guestRef, Order order);

        Task<OrderContact> CreateContact(string orderRef, OrderContact contact);


    }
}
