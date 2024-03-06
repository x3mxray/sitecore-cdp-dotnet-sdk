// <copyright file="GuestContext.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models.Interactive
{
    public class GuestContext : Guest
    {
        [JsonPropertyName("orders")]
        public List<OrderContext> Orders { get; set; }

        [JsonPropertyName("dataExtensions")]
        public List<GuestDataExtension> DataExtensions { get; set; }

        [JsonPropertyName("sessions")]
        public List<Session> Sessions { get; set; }
	}

    public class OrderContext : Order
    {
        [JsonPropertyName("orderItems")]
        public List<OrderItemContext> OrderItems { get; set; }
    }

    public class OrderItemContext : OrderItem
    {
        [JsonPropertyName("referenceId")]
        public string ReferenceId { get; set; }
        [JsonPropertyName("itemId")]
        public string ItemId { get; set; }
    }
}
