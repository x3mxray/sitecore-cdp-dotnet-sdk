﻿// <copyright file="Endpoints.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

namespace SitecoreCDP.SDK.Configuration;

/// <summary>
/// API endpoints (urls).
/// </summary>
public static class Endpoints
{
    public static string BaseUrl { get; set; } = "https://api.boxever.com";
    public static string Version { get; set; } = "v2";
    public static class Interactive
    {
        public static class Guest
        {
            public static string GetContext(string guestRef) => $"{BaseUrl}/{Version}/guestContexts/{guestRef}?expand=items.orders(offset:0,limit:100)&source=all&timeout=30000";
            public static string Find(string email) => $"{BaseUrl}/{Version}/guests?email={email}&identifiers.provider=email&identifiers.id={email}";
            public static string Get(string guestRef) => $"{BaseUrl}/{Version}/guests/{guestRef}";
            public static string Create => $"{BaseUrl}/{Version}/guests";
            public static string Update(string guestRef) => $"{BaseUrl}/{Version}/guests/{guestRef}";
        }

        public static class Order
        {
            public static string Get(string orderRef) => $"{BaseUrl}/{Version}/orders/{orderRef}";
            public static string Create(string guestRef) => $"{BaseUrl}/{Version}/orders?guestRef={guestRef}";
            public static string Find(string guestRef) => $"{BaseUrl}/{Version}/orders?guestRef={guestRef}";
        }

        public static class OrderItem
        {
            public static string Find(string orderRef) => $"{BaseUrl}/{Version}/orders/{orderRef}/orderItems";
            public static string Get(string orderItemRef) => $"{BaseUrl}/{Version}/orderItems/{orderItemRef}";
            public static string Create(string orderRef) => $"{BaseUrl}/{Version}/orders/{orderRef}/orderItems";
            public static string Update(string orderItemRef) => $"{BaseUrl}/{Version}/orderItems/{orderItemRef}";
            public static string Delete(string orderItemRef) => $"{BaseUrl}/{Version}/orderItems/{orderItemRef}";
        }
    }

    public static class Batch
    {
        public static string PresignedRequest(string batchRef) => $"{BaseUrl}/{Version}/batches/{batchRef}";
        public static string CheckStatus(string batchRef) => $"{BaseUrl}/{Version}/batches/{batchRef}";
    }

    public static class Stream
    {

    }
}