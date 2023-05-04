namespace SitecoreCDP.SDK.Interfaces
{

    public interface ICdpClient
    {
        IInteractiveApiService InteractiveApi { get; }
        IBatchApiService BatchApi { get; }
        IStreamApiService StreamApi { get; }
    }
}
