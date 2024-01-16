// <copyright file="IAudienceExportApiService.cs" company="Brimit">
// Copyright (c) 2024 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2024-1-16</date>

namespace SitecoreCDP.SDK.Models.AudienceSync
{
    public static class AudienceSyncJobStatus
    {
        public const string Success = "SUCCESS";
        public const string Queued = "QUEUED";
        public const string Processing = "PROCESSING";
        public const string Cancelled = "CANCELLED";
    }
}
