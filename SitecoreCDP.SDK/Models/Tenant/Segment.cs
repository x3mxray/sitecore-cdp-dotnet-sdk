using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SitecoreCDP.SDK.Models.Common;

namespace SitecoreCDP.SDK.Models.Tenant
{
    public class SegmentList
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
        [JsonPropertyName("items")]
        public List<Segment> Segments { get; set; }
    }
    public class Segment
    {
        [JsonPropertyName("friendlyId")]
        public string FriendlyId { get; set; }

        [JsonPropertyName("definition")]
        public Definition Definition { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("executions")]
        public Hreference Executions { get; set; }

        [JsonPropertyName("revisions")]
        public Hreference Revisions { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("lastRunAt")]
        public DateTime LastRunAt { get; set; }

        [JsonPropertyName("lastLiveAt")]
        public DateTime LastLiveAt { get; set; }

        [JsonPropertyName("sample")]
        public List<string> Sample { get; set; }

        [JsonPropertyName("clientKey")]
        public string ClientKey { get; set; }

        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("ref")]
        public string Ref { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("modifiedByRef")]
        public string ModifiedByRef { get; set; }

        [JsonPropertyName("modifiedAt")]
        public DateTime ModifiedAt { get; set; }

        [JsonPropertyName("revision")]
        public int Revision { get; set; }

        [JsonPropertyName("archived")]
        public bool Archived { get; set; }
    }

    public class Definition
    {
        [JsonPropertyName("filterGroups")]
        public List<FilterGroup> FilterGroups { get; set; }
    }
    public class FilterGroup
    {
        [JsonPropertyName("filterGroupType")]
        public string FilterGroupType { get; set; }

        [JsonPropertyName("entity")]
        public string Entity { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("ruleOperator")]
        public string RuleOperator { get; set; }

        [JsonPropertyName("rules")]
        public List<Rule> Rules { get; set; }
    }

    public class Rule
    {
        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("field")]
        public string Field { get; set; }

        [JsonPropertyName("values")]
        public List<string> Values { get; set; }

        [JsonPropertyName("comparator")]
        public string Comparator { get; set; }

        [JsonPropertyName("comparatorDataType")]
        public string ComparatorDataType { get; set; }
    }
}
