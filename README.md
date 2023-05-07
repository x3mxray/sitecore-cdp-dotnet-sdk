# Sitecore CDP/Personalize SDK for .NET

[![SitecoreCDP.SDK](https://img.shields.io/nuget/v/SitecoreCDP.SDK.svg?maxAge=3600)](https://www.nuget.org/packages/SitecoreCDP.SDK/)

The unofficial .Net SDK for Sitecore CDP/Personalize

- [Example](#example)
- [Available services](#available-services)
    - [Batch API](#batch-api)
	- [AudienceSync API](#audiencesync-api)
    - [Interactive API (REST)](#interactive-api-rest)
    - [Stream API](#stream-api)
    - [Tenant API](#tenant-api)
- [FAQ](#faq)
- [Supported Platforms](#supported-platforms)
- [Getting Help](#getting-help)	
- [Helpful Links](#helpful-links)	

## Example
```c#
using SitecoreCDP.SDK;

// initialize client
var cdpClient = new CdpClient(new CdpClientConfig
{
    ClientKey = "tenant-client-key",
    ApiToken = "tenant-api-token",
    
    BaseUrl = "https://api-engage-eu.sitecorecloud.io", // or "https://api.boxever.com"
    Version = "v2"
});

// batch import
var batchRef = await cdpClient.BatchApi.UploadJson("import.json");

...

// check status
var status = await cdpClient.BatchApi.CheckStatus(batchRef);
if (status.Status.Code == BatchStatusCode.Error)
{
	// download log and extract error records
    var logRecords = await cdpClient.BatchApi.DownloadBatchLog(status.Status.LogUri);
    var errorRecords = logRecords.Where(x => x.Code != 200);
}
```

## Available services
At this moment *Batch API*, *Interactive API* and *Audience Sync* are ready. *Stream API* and *Tenant API* are in progress.

### Batch API
Batch API is used to upload guests, orders, and tracking events. The are 3 types of supported import formats:
- Model based: 
```c#
var batchRef = await cdpClient.BatchApi.Upload(new List<Batch>
{
    new BatchGuest { Guest = new Guest() {/* populate fields */ } },
    new BatchOrder {Order = new Order(){ /* populate fields */}},
	...
});
```
- JSON file:
```c#
var batchRef = await cdpClient.BatchApi.UploadJson("import.json");
```
- GZip file:
```c#
var batchRef = await cdpClient.BatchApi.UploadGZip("import.json.gz");
```
Check batch import status and download error log in strongly typed records:
```c#
// check status
var status = await cdpClient.BatchApi.CheckStatus(batchRef);
if (status.Status.Code == BatchStatusCode.Error)
{
	// download log and extract error records
    var logRecords = await cdpClient.BatchApi.DownloadBatchLog(status.Status.LogUri);
    var errorRecords = logRecords.Where(x => x.Code != 200);
}
```

### AudienceSync API
AudienceSync REST API to trigger and retrieve batch jobs, download output files.
```c#
var triggerResponse = await cdpClient.AudienceSyncApi.Trigger(flowRef, segmentRef, datasetDate);

var jobStatus = await cdpClient.AudienceSyncApi.CheckStatus(triggerResponse.Ref);
if (jobStatus.Status == TriggerResponseStatus.Success)
{
    await cdpClient.AudienceSyncApi.GetOutputFiles(triggerResponse.Ref, "outputFiles.gz");
}
```

### Interactive API (REST)
- Guest API:  `cdpClient.InteractiveApi.Guests`
- Guest Data extensions API: `cdpClient.InteractiveApi.GuestExtensions`
- Orders API: `cdpClient.InteractiveApi.Orders`
- OrderItems API: `cdpClient.InteractiveApi.OrderItems`

### Stream API
In progress.
```c#
await cdpClient.StreamApi.RunExperiment(friendlyId);
await cdpClient.StreamApi.IdentifyUser(new IdentityEvent{});
await cdpClient.StreamApi.TrackEvent(new Event{});
await cdpClient.StreamApi.CreateNewSession();
await cdpClient.StreamApi.AbandonSession();
```
### Tenant API
In progress.

## FAQ

#### Do I have to use `async`/`await` when calling endpoints?
Yes. The SDK uses `HttpClient`, which does not support synchronous calls (and for good reason). Do _not_ use `.Result` or `.Wait()` on calls made with this SDK, ever. These will block threads and potentially cause deadlocks. In short, [don't block on async code](https://blog.stephencleary.com/2012/07/dont-block-on-async-code.html). Use `await`.

## Supported Platforms
The SDK is available with .NET 7.0, .NET Framework 4.6.x and .NET Standard 2.x that makes it compatible with almost all .NET solutions.

## Getting Help
For programming questions you can ask me in Sitecore Slack channels @x3mxray.

To report a bug or request a feature specific to the SDK, please open an [issue](https://github.com/x3mxray/sitecore-cdp-dotnet-sdk/issues/new). 

## Helpful Resources
- [CDP Integrations - Developer Portal](https://developers.sitecore.com/learn/integrations)
- [Sitecore CDP developer documentation](https://doc.sitecore.com/cdp/en/developers/api/index-en.html)
- [Dylan Young: JS SDK/API spec/Postman collection](https://github.com/dylanyoung-dev?tab=repositories)
