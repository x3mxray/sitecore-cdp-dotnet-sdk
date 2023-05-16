// <copyright file="IAudienceSyncApiService.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

using System;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Models.Batch;

namespace SitecoreCDP.SDK.Interfaces
{
    /// <summary>
    /// Audience sync REST API to retrieve batch jobs.
    /// </summary>
    public interface IAudienceSyncApiService
    {
        /// <summary>
        /// Triggering the Audience Sync
        /// </summary>
        /// <param name="flowRef">Reference of the audience sync.</param>
        /// <param name="segmentRef">Reference of the segment that is being used.</param>
        /// <param name="datasetDate">The dataset date of the segment build.</param>
        Task<BatchJob> Trigger(string flowRef, string segmentRef, DateTime datasetDate);

        /// <summary>
        /// Retrieve batch job with status.
        /// </summary>
        /// <param name="batchJobRef">Ref field of BatchJob.</param>
        /// <returns></returns>
        Task<BatchJob> GetBatchJob(string batchJobRef);

        /// <summary>
        /// Retrieves a list of batch jobs for a flow.
        /// </summary>
        /// <param name="flowRef">The flow reference.</param>
        Task<BatchJobs> GetBatchJobs(string flowRef);

        /// <summary>
        /// Retrieves signed URLs for a batch job, download files if needed. 
        /// </summary>
        /// <param name="batchJobRef">The reference of the batch job.</param>
        /// <param name="downloadFileName">Path to downloaded file (default is null - without downloading). If there are more than one file, all will be downloaded with postfix _{index}</param>
        Task<OutputFilesResponse> GetOutputFiles(string batchJobRef, string downloadFileName=null);
    }
}
