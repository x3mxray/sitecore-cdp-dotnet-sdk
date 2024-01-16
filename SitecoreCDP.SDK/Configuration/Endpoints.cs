// <copyright file="Endpoints.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

using SitecoreCDP.SDK.Models.Interactive;

namespace SitecoreCDP.SDK.Configuration
{
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
                public static string GetContext(string guestRef) =>
                    $"{BaseUrl}/{Version}/guestContexts/{guestRef}?expand=items.orders(offset:0,limit:100)&source=all&timeout=30000";

                public static string FindByParameter(GuestParameter parameter, string value) =>
                    $"{BaseUrl}/{Version}/guests?{parameter}={value}";
                public static string FindByIdentifier(string provider, string value) =>
                    $"{BaseUrl}/{Version}/guests?identifiers.provider={provider}&identifiers.id={value}";
                public static string Get(string guestRef) => $"{BaseUrl}/{Version}/guests/{guestRef}";
                public static string Create => $"{BaseUrl}/{Version}/guests";
                public static string Update(string guestRef) => $"{BaseUrl}/{Version}/guests/{guestRef}";
            }

            public static class GuestExtensions
            {
                public static string Find(string guestRef, string extName) =>
                    $"{BaseUrl}/{Version}/guests/{guestRef}/ext{extName}";

                public static string CreateOrUpdate(string guestRef, string extName) =>
                    $"{BaseUrl}/{Version}/guests/{guestRef}/ext{extName}";

                public static string Get(string guestRef, string extName, string guestExtensionRef) =>
                    $"{BaseUrl}/{Version}/guests/{guestRef}/ext{extName}/{guestExtensionRef}";

                public static string Delete(string guestRef, string extName) =>
                    $"{BaseUrl}/{Version}/guests/{guestRef}/ext{extName}";
            }

            public static class Order
            {
                public static string Get(string orderRef) => $"{BaseUrl}/{Version}/orders/{orderRef}";
                public static string Create(string guestRef) => $"{BaseUrl}/{Version}/orders?guestRef={guestRef}";
                public static string Find(string guestRef) => $"{BaseUrl}/{Version}/orders?guestRef={guestRef}";
            }

            public static class OrderContact
            {
	            public static string Create(string orderRef) => $"{BaseUrl}/{Version}/orders/{orderRef}/contacts";
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

        public static class AudienceSync
        {
            public static string Trigger => $"{BaseUrl}/{Version}/batchFlowsTrigger";
            public static string GetJob(string batchJobRef) => $"{BaseUrl}/{Version}/batchFlowsJob/{batchJobRef}";

            public static string GetFiles(string batchJobRef) => $"{BaseUrl}/{Version}/batchFlowOutput/{batchJobRef}/files";

            public static string GetJobs(string flowRef) => $"{BaseUrl}/{Version}/batchFlowsJob/?flowRef={flowRef}&expand=true";

        }

        public static class AudienceExport
        {
	        public static string GetLatestExport(string audienceExportRef) => $"{BaseUrl}/{Version}/audienceExports/definitions/{audienceExportRef}/latestExport";
	        public static string GetFinishedExportJobs(string audienceExportRef) => $"{BaseUrl}/{Version}/audienceExports/definitions/{audienceExportRef}/reports";
	        public static string GetExportJob(string jobExecutionRef) => $"{BaseUrl}/{Version}/audienceExports/executions/{jobExecutionRef}/export";
		}

		public static class Stream
        {

        }

        public static class Tenant
        {
            public static string Configuration => $"{BaseUrl}/{Version}/configurations";
            public static string PointOfSale => $"{BaseUrl}/{Version}/tenants/points-of-sale";
            public static string PointOfSaleDelete(string name) => $"{BaseUrl}/{Version}/tenants/points-of-sale/{name}";
            public static string IdentityRules => $"{BaseUrl}/{Version}/tenants/identity-rules";
            public static class Connections
            {
                public static string Get(string connectionRef) => $"{BaseUrl}/{Version}/connections/{connectionRef}";
                public static string Create => $"{BaseUrl}/{Version}/connections";
            }

            public static class Segments
            {
                public static string Get(string segmentRef) => $"{BaseUrl}/v4/segmentDefinitions/{segmentRef}";
                public static string GetAll => $"{BaseUrl}/v4/segmentDefinitions";
            }

            public static class Users
            {
                public static string Get(string userRef) => $"{BaseUrl}/{Version}/users/{userRef}";
                public static string GetAll(int limit, int offset) => $"{BaseUrl}/{Version}/users?limit={limit}&offset={offset}";
            }
        }
    }
}