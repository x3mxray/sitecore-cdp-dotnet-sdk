﻿// <copyright file="OrderItem.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

using System;
using System.Text.Json.Serialization;

namespace SitecoreCDP.SDK.Models
{
    public class OrderItem
    {
        [JsonPropertyName("type")] public string Type { get; set; } = "OTHER";

        [JsonPropertyName("productId")]
        public string ProductId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("orderedAt")]
        public DateTime OrderedAt { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("originalPrice")]
        public decimal OriginalPrice { get; set; }

        [JsonPropertyName("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("originalCurrencyCode")]
        public string OriginalCurrencyCode { get; set; } 

        [JsonPropertyName("referenceId")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("status")] public string Status { get; set; } = "PURCHASED";

    }
}
