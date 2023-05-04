namespace SitecoreCDP.SDK.Configuration;

public class CdpClientConfig
{
    public string ClientKey { get; set; }
    public string ApiToken { get; set; }
    public string ApiEndpoint { get; set; } = "https://api.boxever.com";
    public string Version { get; set; } = "v2";

    public CdpClientBrowserConfig BrowserConfig { get; set; } = null;
}