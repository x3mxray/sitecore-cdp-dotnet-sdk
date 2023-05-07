// <copyright file="Order.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models
{
    public class Order
    {
        [JsonPropertyName("referenceId")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("channel")]
        public string Channel { get; set; } 

        [JsonPropertyName("pointOfSale")]
        public string PointOfSale { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("orderedAt")]
        public DateTime OrderedAt { get; set; }


        [JsonPropertyName("currencyCode")]
        public string CurrencyCode { get; set; }


        [JsonPropertyName("price")]
        public decimal Price { get; set; }


        [JsonPropertyName("paymentType")]
        public string PaymentType { get; set; }

        //[JsonPropertyName("cardType")] public string CardType { get; set; }

        [JsonPropertyName("contact")]
        public Guest Contact { get; set; }

        [JsonPropertyName("orderItems")]
        public List<OrderItem> OrderItems { get; set; }

    }
}
