// <copyright file="IInteractiveApiOrderItemService.cs" company="Brimit">
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
    /// OrderItems service
    /// </summary>
    interface IInteractiveApiOrderItemService
    {
        /// <summary>
        /// Get an order item object.
        /// </summary>
        /// <param name="orderItemRef">The reference of the order item.</param>
        /// <returns></returns>
        Task<OrderItem> Get(string orderItemRef);
        /// <summary>
        /// Retrieves an order.
        /// </summary>
        /// <param name="orderRef">The reference of the order.</param>
        /// <returns></returns>
        IAsyncEnumerable<OrderItem> Find(string orderRef);
        /// <summary>
        /// Delete an order item.
        /// </summary>
        /// <param name="orderItemRef">The reference of the order item.</param>
        /// <returns></returns>
        Task<OrderItem> Delete(string orderItemRef);

        /// <summary>
        /// Update an order item object.
        /// </summary>
        /// <param name="orderItemRef">The reference of the order item.</param>
        /// <param name="orderItem">Order item model.</param>
        /// <returns></returns>
        Task<OrderItem> Update(string orderItemRef, OrderItem orderItem);

        Task<Models.OrderItem> Create(string orderRef, Models.OrderItem item);

    }
}
