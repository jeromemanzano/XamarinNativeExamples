using Newtonsoft.Json;
using XamarinNativeExamples.Core.Services.WebSocketServices.Messages.Requests;

namespace XamarinNativeExamples.Core.Services.WebSocketServices.Messages.Responses
{
    internal class ErrorMessageResponse: SocketMessageResponse
    {
        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}
