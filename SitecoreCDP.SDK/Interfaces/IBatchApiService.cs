using SitecoreCDP.SDK.Models.Batch;

namespace SitecoreCDP.SDK.Interfaces;

public interface IBatchApiService
{
    string Upload(string tempJsonfileName, List<Batch> batches);
    BatchUploadResponse CheckStatus(string batchRef);
    List<BatchLog> DownloadBatchLog(string tempGzfileName, string uri);
    List<BatchLog> DownloadBatchLogInMemory(string uri);
}