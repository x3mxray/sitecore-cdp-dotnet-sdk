using System.IO.Compression;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using SitecoreCDP.SDK.Configuration;
using SitecoreCDP.SDK.Interfaces;
using SitecoreCDP.SDK.Models;
using SitecoreCDP.SDK.Models.Batch;

namespace SitecoreCDP.SDK.Services
{
    public class BatchApiService : BaseService, IBatchApiService
    {
        public BatchApiService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {
           
        }

        public string Upload(string tempJsonfileName, List<Batch> batches)
        {
            string uniqueId = Guid.NewGuid().ToString();
            var jsonName = tempJsonfileName;

            Helpers.ExportToJson(jsonName, batches);

            
            var gzip = Helpers.CompressFile(jsonName);
            var md5 = Helpers.Md5Hash(gzip);

            PreSignRequest request = new()
            {
                checksum = Helpers.CheckSum(md5),
                size = new FileInfo(gzip).Length
            };

            var textContent = JsonSerializer.Serialize(request);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var uri = new Uri(Endpoints.Batch.PresignedRequest(uniqueId));
            var result = _httpClient.PutAsync(uri, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var putResponse = result.Content.ReadAsStringAsync().Result;
                var responseOnj = JsonSerializer.Deserialize<PreSignResponse>(putResponse);
                if (responseOnj != null && responseOnj.Location != null && !string.IsNullOrEmpty(responseOnj.Location.Href))
                {
                    HttpClient client = new();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpRequestMessage requestMessage = new(HttpMethod.Put, new Uri(responseOnj.Location.Href));

                    requestMessage.Headers.Add("x-amz-server-side-encryption", "AES256");

                    requestMessage.Content = new ByteArrayContent(File.ReadAllBytes(gzip));
                    requestMessage.Content.Headers.ContentMD5 = md5;

                    HttpResponseMessage responseMessage = client.SendAsync(requestMessage).Result;

                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        var response = responseMessage.Content.ReadAsStringAsync().Result;
                        throw CdpException(response);

                    }
                   
                }
            }
            return uniqueId;
        }

        public BatchUploadResponse CheckStatus(string batchRef)
        {
            var uri = new Uri(Endpoints.Batch.CheckStatus(batchRef));
            var result = _httpClient.GetAsync(uri).Result;
            var response = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<BatchUploadResponse>(response);
            }

            throw CdpException(response);
        }

        public List<BatchLog> DownloadBatchLog(string tempGzfileName, string uri)
        {
            using var wc = new WebClient();
            wc.DownloadFile(uri, tempGzfileName);
            var jsonFileName = tempGzfileName.Replace(".gz", ".json");
            using (Stream input = new GZipStream(File.OpenRead(tempGzfileName),CompressionMode.Decompress))
            {
                using (var output = File.Create(jsonFileName))
                {
                    int buffSize = 2048;
                    byte[] outBuffer = new byte[2048];
                    while (true)
                    {
                        buffSize = input.Read(outBuffer, 0, buffSize);
                        if (buffSize > 0)
                        {
                            output.Write(outBuffer, 0, buffSize);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            var jsonEntries = File.ReadAllLines(jsonFileName);
            List<BatchLog> result = new();
            foreach (var jsonEntry in jsonEntries)
            {
                result.Add(JsonSerializer.Deserialize<BatchLog>(jsonEntry));
            }
            return result;
        }

        public List<BatchLog> DownloadBatchLogInMemory(string uri)
        {
            using var wc = new WebClient();
            wc.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
            var data = wc.DownloadData(uri);
            var decompress = Helpers.DecompressFile(data);
            string text = System.Text.Encoding.ASCII.GetString(decompress);
            string[] jsonEntries = text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
          
            List<BatchLog> result = new();
            foreach (var jsonEntry in jsonEntries)
            {
                result.Add(JsonSerializer.Deserialize<BatchLog>(jsonEntry));
            }
            return result;
        }
    }
}
