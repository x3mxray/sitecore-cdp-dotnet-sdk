﻿// <copyright file="IInteractiveApiOrderItemService.cs" company="Brimit">
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
        /// Retrieves a list of order items for an order.
        /// </summary>
        /// <param name="orderRef">The reference of the order.</param>
        /// <returns></returns>
        Task<OrderItem> Get(string orderRef);
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
    }
}
