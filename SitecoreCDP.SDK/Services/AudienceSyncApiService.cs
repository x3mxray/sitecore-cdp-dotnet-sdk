using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using SitecoreCDP.SDK.Configuration;
using SitecoreCDP.SDK.Interfaces;
using SitecoreCDP.SDK.Models.Batch;

namespace SitecoreCDP.SDK.Services
{
    internal class AudienceSyncApiService : BaseService, IAudienceSyncApiService
    {
        public async Task<TriggerResponse> Trigger(string flowRef, string segmentRef, DateTime datasetDate)
        {
            TriggerReguest request = new()
            {
                flowRef = flowRef,
                segmentRef = segmentRef,
                datasetDate = datasetDate.ToString("O")
            };

            var textContent = JsonSerializer.Serialize(request);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var uri = new Uri(Endpoints.AudienceSync.Trigger);
            var result = await _httpClient.PostAsync(uri, content);
            return await GetCdpResponse<TriggerResponse>(result);
        }

        public async Task<TriggerResponse> CheckStatus(string batchJobRef)
        {
            var uri = new Uri(Endpoints.AudienceSync.Status(batchJobRef));
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<TriggerResponse>(result);
        }

        public void GetBatchJobs(string flowRef)
        {
            throw new NotImplementedException();
        }

        public void GetBatchJob(string batchJobRef)
        {
            throw new NotImplementedException();
        }

        public async Task GetOutputFiles(string batchJobRef, string tempGzipName)
        {
            var uri = new Uri(Endpoints.AudienceSync.GetFiles(batchJobRef));
            var result = await _httpClient.GetAsync(uri);
            var response = await GetCdpResponse<OutputFilesResponse>(result);
            if (response.Status == "SUCCESS")
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(response.SignedUrls[0], tempGzipName);
            }
        }

        public AudienceSyncApiService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
        }
    }
}
