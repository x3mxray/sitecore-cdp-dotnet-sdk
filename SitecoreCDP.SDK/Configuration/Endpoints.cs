﻿namespace SitecoreCDP.SDK.Configuration;

public static class Endpoints
{
    public static string ApiEndpoint { get; set; } = "https://api.boxever.com";
    public static string Version { get; set; } = "v2";
    public static class Interactive
    {
        public static class Guest
        {
            public static string GetContext(string guestRef) => $"{ApiEndpoint}/{Version}/guestContexts/{guestRef}?expand=items.orders(offset:0,limit:100)&source=all&timeout=30000";
            public static string Find(string email) => $"{ApiEndpoint}/{Version}/guests?email={email}&identifiers.provider=email&identifiers.id={email}";
            public static string Get(string guestRef) => $"{ApiEndpoint}/{Version}/guests/{guestRef}";
            public static string Create => $"{ApiEndpoint}/{Version}/guests";
            public static string Update(string guestRef) => $"{ApiEndpoint}/{Version}/guests/{guestRef}";
        }

        public static class Order
        {
            public static string Get(string orderRef) => $"{ApiEndpoint}/{Version}/orders/{orderRef}";
            public static string Create(string guestRef) => $"{ApiEndpoint}/{Version}/orders?guestRef={guestRef}";
            public static string Find(string guestRef) => $"{ApiEndpoint}/{Version}/orders?guestRef={guestRef}";
        }

        public static class OrderItem
        {
            public static string Find(string orderRef) => $"{ApiEndpoint}/{Version}/orders/{orderRef}/orderItems";
            public static string Get(string orderItemRef) => $"{ApiEndpoint}/{Version}/orderItems/{orderItemRef}";
            public static string Create(string orderRef) => $"{ApiEndpoint}/{Version}/orders/{orderRef}/orderItems";
            public static string Update(string orderItemRef) => $"{ApiEndpoint}/{Version}/orderItems/{orderItemRef}";
            public static string Delete(string orderItemRef) => $"{ApiEndpoint}/{Version}/orderItems/{orderItemRef}";
        }
    }

    public static class Batch
    {
        public static string PresignedRequest(string batchRef) => $"{ApiEndpoint}/{Version}/batches/{batchRef}";
        public static string CheckStatus(string batchRef) => $"{ApiEndpoint}/{Version}/batches/{batchRef}";
    }

    public static class Stream
    {

    }
}