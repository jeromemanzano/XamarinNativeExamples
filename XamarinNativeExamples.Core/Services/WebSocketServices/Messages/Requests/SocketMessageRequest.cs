using Newtonsoft.Json;

namespace XamarinNativeExamples.Core.Services.WebSocketServices.Messages.Requests
{
    internal class SocketMessageRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
