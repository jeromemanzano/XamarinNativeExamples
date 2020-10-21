using Newtonsoft.Json;

namespace XamarinNativeExamples.Core.Services.WebSocketServices.Messages.Responses
{
    internal class SocketMessageResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
