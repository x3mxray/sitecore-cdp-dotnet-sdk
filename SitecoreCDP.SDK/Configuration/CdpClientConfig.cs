// <copyright file="CdpClientConfig.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>
namespace SitecoreCDP.SDK.Configuration;

/// <summary>
///  Configuration model for CdpClient
/// </summary>
public class CdpClientConfig
{
    /// <summary>
    /// Client Key from Sitecore CDP settings.
    /// </summary>
    public string ClientKey { get; set; }
    /// <summary>
    /// API Token from Sitecore CDP settings.
    /// </summary>
    public string ApiToken { get; set; }
    /// <summary>
    /// Base url for all request. Like  "https://api.boxever.com" or "https://api-engage-eu.sitecorecloud.io".
    /// </summary>
    public string BaseUrl { get; set; } = "https://api.boxever.com";
    /// <summary>
    /// API version. Used in all requests, like <BaseUrl>/<Version>/<ApiEndpoint>
    /// </summary>
    public string Version { get; set; } = "v2";

    /// <summary>
    /// Default (fallback) values for Stream API requests.
    /// </summary>
    public CdpClientBrowserConfig BrowserConfig { get; set; } = null;
}