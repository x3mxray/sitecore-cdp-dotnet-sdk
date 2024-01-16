// <copyright file="IAudienceExportApiService.cs" company="Brimit">
// Copyright (c) 2024 All Rights Reserved.
// </copyright>
// <author>Sergey Baranov @x3mxray</author>
// <project>SitecoreCDP.SDK</project>
// <date>2024-1-16</date>

using System.Threading.Tasks;
using SitecoreCDP.SDK.Models.AudienceExport;

namespace SitecoreCDP.SDK.Interfaces
{
	/// <summary>
	/// Audience Export REST API to access the output of an audience export job.
	/// </summary>
	public interface IAudienceExportApiService
	{
		/// <summary>
		/// Retrieve output URLs for the latest export job
		/// </summary>
		/// <param name="audienceExportRef">The reference of the audience export.</param>
		Task<AudienceExportJob> GetLatestExportJob(string audienceExportRef);

		/// <summary>
		/// Retrieve finished export jobs
		/// </summary>
		/// <param name="audienceExportRef">he reference of the audience export.</param>
		Task<AudienceExportJobFinished> GetFinishedExportJobs(string audienceExportRef);

		/// <summary>
		/// Retrieve output URLs for an export job
		/// </summary>
		/// <param name="jobExecutionRef">The reference of the audience export job.</param>
		Task<AudienceExportJob> GetExportJob(string jobExecutionRef);
	}
}
