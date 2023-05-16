using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SitecoreCDP.SDK.Models.Common;

namespace SitecoreCDP.SDK.Models.Batch
{
    public class TriggerReguest
    {
        public string flowRef { get; set; }
        public string segmentRef { get; set; }
        public string datasetDate { get; set; }
    }

    public class BatchJobs: Hreference
    {
        [JsonPropertyName("first")]
        public Hreference First { get; set; }

        [JsonPropertyName("next")]
        public Hreference Next { get; set; }

        [JsonPropertyName("items")]
        public List<BatchJob> Items { get; set; }

    }

    public class BatchJob : Hreference
    {
        [JsonPropertyName("ref")]
        public string Ref { get; set; }
        [JsonPropertyName("flowRef")]
        public string FlowRef { get; set; }
        [JsonPropertyName("segmentRef")]
        public string SegmentRef { get; set; }
        [JsonPropertyName("datasetDate")]
        public DateTime DatasetDate { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("statusDescription")]
        public string StatusDescription { get; set; }
        [JsonPropertyName("s3GuestContextPath")]
        public string S3GuestContextPath { get; set; }
        [JsonPropertyName("s3FlowExecutionPath")]
        public string S3FlowExecutionPath { get; set; }
        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }
        [JsonPropertyName("guestContextSize")]
        public int GuestContextSize { get; set; }
        [JsonPropertyName("segmentSize")]
        public int SegmentSize { get; set; }
        [JsonPropertyName("numberPartitions")]
        public int NumberPartitions { get; set; }
        [JsonPropertyName("applicationVersion")]
        public int ApplicationVersion { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("modifiedAt")]
        public DateTime ModifiedAt { get; set; }
    }
}
