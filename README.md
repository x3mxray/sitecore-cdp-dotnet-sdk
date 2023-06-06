# Sitecore CDP/Personalize SDK for .NET

[![SitecoreCDP.SDK](https://img.shields.io/nuget/v/SitecoreCDP.SDK.svg?maxAge=3600)](https://www.nuget.org/packages/SitecoreCDP.SDK/) [![Downloads](https://img.shields.io/nuget/dt/SitecoreCDP.SDK.svg)](https://www.nuget.org/packages/SitecoreCDP.SDK/)

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
At this moment **Batch API**, **Interactive API** and **Audience Sync** are ready. *Stream API* and *Tenant API* are in progress.

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
// by file name
var batchRef = await cdpClient.BatchApi.UploadJson("import.json");

// by file stream 
var batchRef = await cdpClient.BatchApi.UploadJson(jsonFileBytes);
```
- GZip file:
```c#
// by file name
var batchRef = await cdpClient.BatchApi.UploadGZip("import.json.gz");

// by file stream 
var batchRef = await cdpClient.BatchApi.UploadGZip(gzFileBytes);
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

// get batch job and check status
var jobStatus = await cdpClient.AudienceSyncApi.GetBatchJob(triggerResponse.Ref);
if (jobStatus.Status == AudienceSyncJobStatus.Success)
{
    // get file urls
    var outputFiles = await _cdpClient.AudienceSyncApi.GetOutputFiles(triggerResponse.Ref);
    foreach (var fileUrl in outputFiles.SignedUrls)
    {
        // do something
    }
	
	// or download files
	var outputFiles = await _cdpClient.AudienceSyncApi.GetOutputFiles(triggerResponse.Ref, "outputFiles.gz");
	// if there is nore than one file, they will be saved as outputFiles_0.gz, outputFiles_1.gz, etc.
}


// get batch jobs from Flow:
var jobs = await _cdpClient.AudienceSyncApi.GetBatchJobs(flowRef);
foreach (var job in jobs.Items)
{
    if (job.Status == AudienceSyncJobStatus.Success)
    {
        // do something
    }
}
```

### Interactive API (REST)
- Guest API:  `cdpClient.InteractiveApi.Guests`
```c#
// create guest:
var newGuest = new GuestCreate
{
    Email = "x3m.xray@gmail.com",
    FirstName = "Sergey",
    LastName = "Baranov",
    Gender = Gender.Male,
    PhoneNumbers = new List<string> { "+99988877766" },
	...
    Identifiers = new List<Identifier>
    {
        new Identifier { Provider = "email", Id = "x3m.xray@gmail.com" },
		new Identifier { Provider = "CMS_ID", Id = "12345" },
    }
};
var result = await _cdpClient.InteractiveApi.Guests.Create(newGuest);

// update guest:
newGuest.DateOfBirth = new DateTime(1986,5,25);
var updateResult = await _cdpClient.InteractiveApi.Guests.Update(result.Ref, newGuest);

// find guest with context (extensions and orders) by identifier:
var user = await _cdpClient.InteractiveApi.Guests.FindByIdentifier(identityProvider: "CMS_ID", identityValue: "12345");

// find guest with context by parameter:
var guests =  await _cdpClient.InteractiveApi.Guests.FindByParameter(GuestParameter.email, "x3m.xray@gmail.com").ToListAsync();
var me = guests.First();

// Get guest context by guestRef:
var guest = await _cdpClient.InteractiveApi.Guests.GetContext(me.Ref);
```

- Guest Data extensions API: `cdpClient.InteractiveApi.GuestExtensions`:
```c#
// create custom guest data extension:
public class DemoExt : DataExtension
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
	
    [JsonPropertyName("logic")]
    public bool Logic { get; set; }
	
    [JsonPropertyName("number")]
    public int Number { get; set; }
}

// populate values
var dataExt = new DemoExt
{
    Key = "demo",
    Text = "lorem ipsum",
    Logic = true,
    Number = 456
};
var result = await _cdpClient.InteractiveApi.GuestExtensions.CreateOrUpdate(guestRef, "custom", dataExt);

// get extension items by extension name	
var ext = await _cdpClient.InteractiveApi.GuestExtensions.Get(guestRef, "custom");
var items = ext.Items;

// get extension item by extension name and extension itemRef
var ext = await _cdpClient.InteractiveApi.GuestExtensions.Get(guestRef, "custom", extensionItemRef);
Dictionary<string, dynamic> items = ext.Values;

// delete extension
await _cdpClient.InteractiveApi.GuestExtensions.Delete(guestRef, "custom");
```

- Orders API: `cdpClient.InteractiveApi.Orders`:
```c#
// get order by orderRef:
var order = await _cdpClient.InteractiveApi.Orders.Get(orderRef);

// get guest orders:
var orders = await _cdpClient.InteractiveApi.Orders.Find(guestRef).ToListAsync();
foreach (var order in orders)
{
    // access to order items, contacts, payment, etc.
}
```

- OrderItems API: `cdpClient.InteractiveApi.OrderItems`:
```c#
// get all order items by orderRef:
var orderItems = await _cdpClient.InteractiveApi.OrderItems.Find(orderRef).ToListAsync();
foreach (var item in orderItems)
{
    // access to order item fields
}

// get single order item:
var orderItem = await _cdpClient.InteractiveApi.OrderItems.Get(item.Ref);

// delete order item:
await _cdpClient.InteractiveApi.OrderItems.Delete(item.Ref);
```

### Stream API
In progress.

### Tenant API
- Settings and configurations:
```
// get tenant settings and configurations:
TenantConfiguration config = await _cdpClient.TenantApi.GetConfiguration();

// get tenant point of sales list:
List<PointOfSale> pos = await _cdpClient.TenantApi.GetPointOfSales();

// get tenant Identity rules:
List<IdentityRules> identityRules = await _cdpClient.TenantApi.GetIdentityRules();
```

- Connections API:  `cdpClient.TenantApi.Connections`:
```
// get connection:
Connection connection = await _cdpClient.TenantApi.Connections.Get("ee202d47-6bb6-4d4d-84e5-5adcd4d07013");
 
// create connection:
connection.Name = "new connection";
var newConnection = await _cdpClient.TenantApi.Connections.Create(connection);

// update connection:
newConnection.Auth = new Auth { AuthType = "NONE" };
await _cdpClient.TenantApi.Connections.Update(newConnection);
```

- Batch Segments API: `cdpClient.TenantApi.BatchSegments`:
```
// get by ref:
var batchSegment = await _cdpClient.TenantApi.BatchSegments.Get("d99c8189-32a2-4549-8193-afc091efd9d2");

// get by friendly name:
var batchSegment = await _cdpClient.TenantApi.BatchSegments.Get("demo_brimit");

// get all batch segments:
List<Segment> batchSegments = await _cdpClient.TenantApi.BatchSegments.GetAll();
```

- Tenant Users API: `cdpClient.TenantApi.Users`
```
// get information about tenant user (with roles and permissions):
User tenantUser = await _cdpClient.TenantApi.Users.Get("e7198a5d-26d2-4420-938f-950c1a487bd1");

// get all tenant users:
var users = await _cdpClient.TenantApi.Users.GetAll(limit: 100, offset: 0);
```

## FAQ

#### Does it support`async`/`await`?
Yes. 

#### Does it use 3rd party http client when calling endpoints?
No, default `HttpClient` is used. 

#### Any references to libraries that versions should be taken into account *(like Newtonsoft.Json)*?
No.

#### Is SDK covered by test?
Yes and no :) For each new API/endpoint a test is written, but it is still local, because you need a tenant to run them.  I'm not posting them publicly yet.

## Supported Platforms
The SDK is available with .NET 7.0, .NET Framework 4.6.x and .NET Standard 2.x that makes it compatible with almost all .NET solutions.

## Getting Help
For programming questions you can ask me in Sitecore Slack channels @x3mxray.

To report a bug or request a feature specific to the SDK, please open an [issue](https://github.com/x3mxray/sitecore-cdp-dotnet-sdk/issues/new). 

## Helpful Resources
- [CDP Integrations - Developer Portal](https://developers.sitecore.com/learn/integrations)
- [Sitecore CDP developer documentation](https://doc.sitecore.com/cdp/en/developers/api/index-en.html)
- [Dylan Young: JS SDK/API spec/Postman collection](https://github.com/dylanyoung-dev?tab=repositories)
