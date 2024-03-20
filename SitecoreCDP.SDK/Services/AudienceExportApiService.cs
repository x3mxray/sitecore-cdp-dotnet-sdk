// <copyright file="IAudienceExportApiService.cs" company="Brimit">
// Copyright (c) 2024 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2024-1-16</date>
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Auth;
using SitecoreCDP.SDK.Configuration;
using SitecoreCDP.SDK.Interfaces;
using SitecoreCDP.SDK.Models.AudienceExport;
using SitecoreCDP.SDK.Models.Batch;

namespace SitecoreCDP.SDK.Services
{
	internal class AudienceExportApiService : BaseService, IAudienceExportApiService
	{
		public async Task<AudienceExportJob> GetLatestExportJob(string audienceExportRef)
		{
			var uri = new Uri(Endpoints.AudienceExport.GetLatestExport(audienceExportRef));
			var result = await _httpClient.GetAsync(uri);
			return await GetCdpResponse<AudienceExportJob>(result);
		}

		public async Task<List<AudienceExportJobFinished>> GetFinishedExportJobs(string audienceExportRef)
		{
			var uri = new Uri(Endpoints.AudienceExport.GetFinishedExportJobs(audienceExportRef));
			var result = await _httpClient.GetAsync(uri);
			return await GetCdpResponse<List<AudienceExportJobFinished>>(result);
		}

		public async Task<AudienceExportJob> GetExportJob(string jobExecutionRef)
		{
			var uri = new Uri(Endpoints.AudienceExport.GetExportJob(jobExecutionRef));
			var result = await _httpClient.GetAsync(uri);
			return await GetCdpResponse<AudienceExportJob>(result);
		}
		public AudienceExportApiService(CdpClientConfig cdpClientConfig, AuthType authType=AuthType.ApiKey) : base(cdpClientConfig)
		{
			switch (authType)
			{
				case AuthType.ApiKey: this.UseApiKeyAuth(); break;
				case AuthType.CloudUser: this.UseCloudAuth(); break;
			}
		}

		public async Task<List<T>> DownloadExportDelta<T>(string uri, string tempGzipName = null)
		{
			//if (string.IsNullOrEmpty(tempGzipName))
			//	return await DownloadBatchLogInMemory(uri);

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
			List<T> result = new List<T>();
			foreach (var jsonEntry in jsonEntries)
			{
				result.Add(JsonSerializer.Deserialize<T>(jsonEntry));
			}
			return result;
		}
	}
}
