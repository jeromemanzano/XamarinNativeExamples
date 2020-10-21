using Newtonsoft.Json;

namespace XamarinNativeExamples.Core.Services.WebSocketServices.Messages.Responses
{
    internal class PriceUpdateMessageResponse : SocketMessageResponse
    {
        [JsonProperty("data")]
        public DataResponse[] Data { get; set; }
    }

    internal class DataResponse 
    {
        [JsonProperty("s")]
        public string Symbol { get; set; }
        [JsonProperty("p")]
        public double Price { get; set; }
        [JsonProperty("v")]
        public double Volume { get; set; }
        [JsonProperty("t")]
        public long UnixTimeStamp { get; set; }
    }
}
