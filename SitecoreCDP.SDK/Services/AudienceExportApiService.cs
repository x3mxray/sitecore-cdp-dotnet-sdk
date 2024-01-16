// <copyright file="IAudienceExportApiService.cs" company="Brimit">
// Copyright (c) 2024 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2024-1-16</date>
using System;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Configuration;
using SitecoreCDP.SDK.Interfaces;
using SitecoreCDP.SDK.Models.AudienceExport;

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

		public async Task<AudienceExportJobFinished> GetFinishedExportJobs(string audienceExportRef)
		{
			var uri = new Uri(Endpoints.AudienceExport.GetFinishedExportJobs(audienceExportRef));
			var result = await _httpClient.GetAsync(uri);
			return await GetCdpResponse<AudienceExportJobFinished>(result);
		}

		public async Task<AudienceExportJob> GetExportJob(string jobExecutionRef)
		{
			var uri = new Uri(Endpoints.AudienceExport.GetExportJob(jobExecutionRef));
			var result = await _httpClient.GetAsync(uri);
			return await GetCdpResponse<AudienceExportJob>(result);
		}
		public AudienceExportApiService(CdpClientConfig cdpClientConfig) : base(cdpClientConfig)
		{
			this.UseSandboxAuth();
		}
	}
}
