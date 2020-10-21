
namespace XamarinNativeExamples.Core.Services.WebSocketServices.Base
{
    internal interface IWebSocketFactory
    {
        IWebSocketClient WebSocketClient { get; }
    }
}
