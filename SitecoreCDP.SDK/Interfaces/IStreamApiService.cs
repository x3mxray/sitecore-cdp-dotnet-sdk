// <copyright file="IStreamApiService.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>
namespace SitecoreCDP.SDK.Interfaces
{
    /// <summary>
    /// The Stream API is used to send real-time behavioral and transactional data about the users of your application to Sitecore CDP.
    /// </summary>
    public interface IStreamApiService
    {
        string CreateNewSession();
        bool KillSession();

        void RunExperiment(string friendlyId);

        void TrackEvent(string eventName = "VIEW");

        void IdentifyUser(string provider, string identifier);
    }
}