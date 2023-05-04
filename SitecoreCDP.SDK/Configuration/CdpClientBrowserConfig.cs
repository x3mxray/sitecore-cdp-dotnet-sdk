namespace SitecoreCDP.SDK.Configuration;

public class CdpClientBrowserConfig
{
    public string Channel { get; set; } = "SDK";
    public string Language { get; set; } = "EN";
    public string CurrencyCode { get; set; } = "USD";
    public string PointOfSale { get; set; } = "undefined";
    public string BrowserId { get; set; }
}