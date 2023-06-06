using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SitecoreCDP.SDK.Models.Tenant
{
    public class Connection
    {
        [JsonPropertyName("clientKey")]
        public string ClientKey { get; set; }

        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("ref")]
        public string Ref { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("modifiedByRef")]
        public string ModifiedByRef { get; set; }

        [JsonPropertyName("modifiedAt")]
        public DateTime ModifiedAt { get; set; }

        [JsonPropertyName("revision")]
        public int Revision { get; set; }

        [JsonPropertyName("archived")]
        public bool Archived { get; set; }

        [JsonPropertyName("auth")]
        public Auth Auth { get; set; }

        [JsonPropertyName("request")]
        public ConnectionRequest Request { get; set; }

        [JsonPropertyName("inputMappings")]
        public List<InputMapping> InputMappings { get; set; }

        [JsonPropertyName("outputMappings")]
        public List<OutputMapping> OutputMappings { get; set; }

        [JsonPropertyName("customHeaders")]
        public List<CustomHeader> CustomHeaders { get; set; }

        [JsonPropertyName("urlParameters")]
        public List<object> UrlParameters { get; set; }

        [JsonPropertyName("systemType")]
        public string SystemType { get; set; }

        [JsonPropertyName("connectionTimeout")]
        public int ConnectionTimeout { get; set; }

        [JsonPropertyName("socketTimeout")]
        public int SocketTimeout { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }



    public class InputMapping
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("exampleValue")]
        public string ExampleValue { get; set; }

        [JsonPropertyName("mapping")]
        public string Mapping { get; set; }
    }

    public class OutputMapping
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("outputReference")]
        public string OutputReference { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class ConnectionRequest
    {
        [JsonPropertyName("requestType")]
        public string RequestType { get; set; }

        [JsonPropertyName("connectionUrl")]
        public string ConnectionUrl { get; set; }

        [JsonPropertyName("requestBody")]
        public string RequestBody { get; set; }
    }

    public class Auth
    {
        [JsonPropertyName("authType")]
        public string AuthType { get; set; }
    }

    public class CustomHeader
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

}
