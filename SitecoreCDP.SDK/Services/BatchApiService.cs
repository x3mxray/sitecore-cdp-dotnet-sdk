// <copyright file="BatchApiService.cs" company="Brimit">
// Copyright (c) 2023 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2023-5-4</date>

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Configuration;
using SitecoreCDP.SDK.Interfaces;
using SitecoreCDP.SDK.Models.Batch;

namespace SitecoreCDP.SDK.Services
{
    public class BatchApiService : BaseService, IBatchApiService
    {
        public BatchApiService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
        {

        }
        public async Task<string> UploadGZip(string gzipFileName)
        {
            string uniqueId = Guid.NewGuid().ToString();
            var gzip = gzipFileName;
            var md5 = Helpers.Md5Hash(gzip);

            PreSignRequest request = new PreSignRequest()
            {
                checksum = Helpers.CheckSum(md5),
                size = new FileInfo(gzip).Length
            };

            var textContent = JsonSerializer.Serialize(request);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var uri = new Uri(Endpoints.Batch.PresignedRequest(uniqueId));
            var result = await _httpClient.PutAsync(uri, content);
            var response = await GetCdpResponse<PreSignResponse>(result);
            if (!string.IsNullOrEmpty(response.Location.Href))
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, new Uri(response.Location.Href));

                requestMessage.Headers.Add("x-amz-server-side-encryption", "AES256");

                requestMessage.Content = new ByteArrayContent(File.ReadAllBytes(gzip));
                requestMessage.Content.Headers.ContentMD5 = md5;

                HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);

                if (!responseMessage.IsSuccessStatusCode)
                {
                    var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                    throw CdpException(errorMessage);

                }

            }
            return uniqueId;
        }
        public async Task<string> UploadGZip(byte[] gzipFileBytes)
        {
            string uniqueId = Guid.NewGuid().ToString();
            var md5 = Helpers.Md5Hash(gzipFileBytes);

            PreSignRequest request = new PreSignRequest()
            {
                checksum = Helpers.CheckSum(md5),
                size = gzipFileBytes.Length
            };

            var textContent = JsonSerializer.Serialize(request);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var uri = new Uri(Endpoints.Batch.PresignedRequest(uniqueId));
            var result = await _httpClient.PutAsync(uri, content);
            var response = await GetCdpResponse<PreSignResponse>(result);
            if (!string.IsNullOrEmpty(response.Location.Href))
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, new Uri(response.Location.Href));

                requestMessage.Headers.Add("x-amz-server-side-encryption", "AES256");

                requestMessage.Content = new ByteArrayContent(gzipFileBytes);
                requestMessage.Content.Headers.ContentMD5 = md5;

                HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);

                if (!responseMessage.IsSuccessStatusCode)
                {
                    var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                    throw CdpException(errorMessage);

                }

            }
            return uniqueId;
        }
        public async Task<string> UploadJson(byte[] jsonFileBytes)
        {
            string uniqueId = Guid.NewGuid().ToString();
            var gzip = Helpers.CompressFile(jsonFileBytes);
            var md5 = Helpers.Md5Hash(gzip);

            PreSignRequest request = new PreSignRequest()
            {
                checksum = Helpers.CheckSum(md5),
                size = gzip.Length
            };

            var textContent = JsonSerializer.Serialize(request);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var uri = new Uri(Endpoints.Batch.PresignedRequest(uniqueId));
            var result = await _httpClient.PutAsync(uri, content);
            var response = await GetCdpResponse<PreSignResponse>(result);
            if (!string.IsNullOrEmpty(response.Location.Href))
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, new Uri(response.Location.Href));

                requestMessage.Headers.Add("x-amz-server-side-encryption", "AES256");

                requestMessage.Content = new ByteArrayContent(gzip);
                requestMessage.Content.Headers.ContentMD5 = md5;

                HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);

                if (!responseMessage.IsSuccessStatusCode)
                {
                    var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                    throw CdpException(errorMessage);
                }
            }
            return uniqueId;
        }

        public async Task<string> UploadJson(string jsonFileName)
        {
            string uniqueId = Guid.NewGuid().ToString();
            var gzip = Helpers.CompressFile(jsonFileName);
            var md5 = Helpers.Md5Hash(gzip);

            PreSignRequest request = new PreSignRequest()
            {
                checksum = Helpers.CheckSum(md5),
                size = new FileInfo(gzip).Length
            };

            var textContent = JsonSerializer.Serialize(request);
            using var content = new StringContent(textContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var uri = new Uri(Endpoints.Batch.PresignedRequest(uniqueId));
            var result = await _httpClient.PutAsync(uri, content);
            var response = await GetCdpResponse<PreSignResponse>(result);
            if (!string.IsNullOrEmpty(response.Location.Href))
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, new Uri(response.Location.Href));

                requestMessage.Headers.Add("x-amz-server-side-encryption", "AES256");

                requestMessage.Content = new ByteArrayContent(File.ReadAllBytes(gzip));
                requestMessage.Content.Headers.ContentMD5 = md5;

                HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);

                if (!responseMessage.IsSuccessStatusCode)
                {
                    var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                    throw CdpException(errorMessage);

                }

            }
            return uniqueId;
        }

        public async Task<string> Upload(List<Batch> batches, string tempJsonfileName)
        {
            var jsonName = tempJsonfileName;

            var bytes = !string.IsNullOrEmpty(tempJsonfileName)
                ? batches.ExportToBatchJsonFile(jsonName)
                : batches.ExportToBatchFile();


            return await UploadJson(bytes);
        }

        public async Task<BatchUploadResponse> CheckStatus(string batchRef)
        {
            var uri = new Uri(Endpoints.Batch.CheckStatus(batchRef));
            var result = await _httpClient.GetAsync(uri);
            return await GetCdpResponse<BatchUploadResponse>(result);
        }

        public async Task<List<BatchLog>> DownloadBatchLog(string uri, string tempGzipName=null)
        {
            if (string.IsNullOrEmpty(tempGzipName))
                return await DownloadBatchLogInMemory(uri);

            using var wc = new WebClient();
            await wc.DownloadFileTaskAsync(uri, tempGzipName);
            var jsonFileName = tempGzipName.Replace(".gz", ".json");
            using (Stream input = new GZipStream(File.OpenRead(tempGzipName), CompressionMode.Decompress))
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
            List<BatchLog> result = new List<BatchLog>();
            foreach (var jsonEntry in jsonEntries)
            {
                result.Add(JsonSerializer.Deserialize<BatchLog>(jsonEntry));
            }
            return result;
        }

        async Task<List<BatchLog>> DownloadBatchLogInMemory(string uri)
        {
            using var wc = new WebClient();
            wc.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
            var data = await wc.DownloadDataTaskAsync(uri);
            var decompress = Helpers.DecompressFile(data);
            string text = System.Text.Encoding.ASCII.GetString(decompress);
            string[] jsonEntries = text.Split(new []{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

            List<BatchLog> result = new List<BatchLog>();
            foreach (var jsonEntry in jsonEntries)
            {
                result.Add(JsonSerializer.Deserialize<BatchLog>(jsonEntry));
            }
            return result;
        }
    }
}
