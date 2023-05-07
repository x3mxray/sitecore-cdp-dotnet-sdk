// <copyright file="CdpClientBrowserConfig.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>
namespace SitecoreCDP.SDK.Configuration
{
    /// <summary>
    /// Default (fallback) values for Stream API requests.
    /// </summary>
    public class CdpClientBrowserConfig
    {
        /// <summary>
        /// The touchpoint where the user interacts with your brand (uppercase).
        /// </summary>
        public string Channel { get; set; } = "WEB";

        /// <summary>
        /// The language the user is using your app in.
        /// </summary>
        public string Language { get; set; } = "EN";

        /// <summary>
        /// The alphabetic currency code of the currency the user is using in your app (uppercase ISO 4217).
        /// </summary>
        public string CurrencyCode { get; set; } = "USD";

        /// <summary>
        /// The name of the point of sale where the interaction with your brand takes place.
        /// </summary>
        public string PointOfSale { get; set; } = "undefined";

        /// <summary>
        /// The browser ID (a universally unique identifier (UUID) that Sitecore CDP assigns to every user of your app).
        /// </summary>
        public string BrowserId { get; set; }
    }
}