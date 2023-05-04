namespace SitecoreCDP.SDK.Interfaces;

public interface IStreamApiService
{
    string CreateNewSession();
    bool KillSession();

    void RunExperiment(string friendlyId);

    void TrackEvent(string eventName = "VIEW");
    void IdentifyUser(string provider, string identifier);
}