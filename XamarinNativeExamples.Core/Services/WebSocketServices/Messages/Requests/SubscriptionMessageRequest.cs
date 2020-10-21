using Newtonsoft.Json;

namespace XamarinNativeExamples.Core.Services.WebSocketServices.Messages.Requests
{
    internal class SubscriptionMessageRequest : SocketMessageRequest
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
