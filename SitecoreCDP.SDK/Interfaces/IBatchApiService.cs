// <copyright file="IBatchApiService.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>
using SitecoreCDP.SDK.Models.Batch;

namespace SitecoreCDP.SDK.Interfaces;

/// <summary>Batch Import service</summary>
public interface IBatchApiService
{
    /// <summary>Prepare and upload the gzipped batch file.</summary>
    /// <param name="batches">Collection of batch entities to upload.</param>
    /// <param name="tempJsonName">Path to temporary json file.</param>
    string Upload(List<Batch> batches, string tempJsonName);
    /// <summary>Retrieve batch file upload status</summary>
    /// <param name="batchRef">The UUID of a batch upload.</param>
    BatchUploadResponse CheckStatus(string batchRef);
    /// <summary>Retrieve batch upload error log</summary>
    /// <param name="uri">The URI of the error log. If you do not know the URI, first retrieve the batch file upload status (CheckStatus). In the response, if the status is error, the BatchUploadResponse.Status.LogUri field contains the URI of the error log.</param>
    /// <param name="tempGzipName">Path to downloaded gzip file if you need to save it, default value is null - process in memory.</param>
    List<BatchLog> DownloadBatchLog(string uri, string tempGzipName=null);
}