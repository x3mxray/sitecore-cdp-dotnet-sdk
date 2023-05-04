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
        Task<TriggerResponse> Trigger(string flowRef, string segmentRef, DateTime datasetDate);

        /// <summary>
        /// Check audience sync status.
        /// </summary>
        /// <param name="batchJobRef">Ref field of TriggerResponse.</param>
        /// <returns></returns>
        Task<TriggerResponse> CheckStatus(string batchJobRef);
        /// <summary>
        /// Retrieves a list of batch jobs for a flow. You must include the flow reference as a query string parameter in the URI of the request.
        /// </summary>
        /// <param name="flowRef">The flow reference.</param>
        void GetBatchJobs(string flowRef);

        /// <summary>
        /// Retrieves a batch job for a flow.
        /// </summary>
        /// <param name="batchJobRef">The reference of the batch job.</param>
        void GetBatchJob(string batchJobRef);

        /// <summary>
        /// Retrieves signed URLs for a batch job, download and parse files. 
        /// </summary>
        /// <param name="batchJobRef">The reference of the batch job.</param>
        /// <param name="tempGzipName">Path to downloaded gzip file.</param>
        Task GetOutputFiles(string batchJobRef, string tempGzipName);
    }
}
