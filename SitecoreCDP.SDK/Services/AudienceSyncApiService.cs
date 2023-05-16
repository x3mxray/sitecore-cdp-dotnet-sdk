using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using SitecoreCDP.SDK.Configuration;
using SitecoreCDP.SDK.Interfaces;
using SitecoreCDP.SDK.Models.Batch;

namespace SitecoreCDP.SDK.Services
{
    internal class AudienceSyncApiService : BaseService, IAudienceSyncApiService
    {
        public async Task<BatchJob> Trigger(string flowRef, string segmentRef, DateTime datasetDate)
        {
            TriggerReguest request = new TriggerReguest()
            {
                flowRef = flowRef,
                segmentRef = segmentRef,
                datasetDate = datasetDate.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'")
            };

            var textContent = JsonSerializer.Serialize(request);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var uri = new Uri(Endpoints.AudienceSync.Trigger);
            var result = await _httpClient.PostAsync(uri, content);
            return await GetCdpResponse<BatchJob>(result);
        }

        public async Task<BatchJob> GetBatchJob(string batchJobRef)
        {
            var uri = new Uri(Endpoints.AudienceSync.GetJob(batchJobRef));
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<BatchJob>(result);
        }

        public async Task<BatchJobs> GetBatchJobs(string flowRef)
        {
            var uri = new Uri(Endpoints.AudienceSync.GetJobs(flowRef));
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<BatchJobs>(result);
        }

        public async Task<OutputFilesResponse> GetOutputFiles(string batchJobRef, string gzipFileName = null)
        {
            var uri = new Uri(Endpoints.AudienceSync.GetFiles(batchJobRef));
            var result = await _httpClient.GetAsync(uri);
            var response = await GetCdpResponse<OutputFilesResponse>(result);
            if(!string.IsNullOrEmpty(gzipFileName) && response.SignedUrls.Any())
            {
                if (response.SignedUrls.Count == 1)
                {
                    using var wc = new WebClient();
                    await wc.DownloadFileTaskAsync(response.SignedUrls[0], gzipFileName);
                }
                else
                {
                    var extension = Path.GetExtension(gzipFileName); 
                    var withoutExtension = Path.Combine(Path.GetDirectoryName(gzipFileName), Path.GetFileNameWithoutExtension(gzipFileName));
                    var index = 0;
                    foreach (var urls in response.SignedUrls)
                    {
                        var name = $"{withoutExtension}_{index}{extension}";
                        using var wc = new WebClient();
                        await wc.DownloadFileTaskAsync(urls, name);
                    }
                }
            }

            return response;
        }

        public AudienceSyncApiService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
        }
    }
}
