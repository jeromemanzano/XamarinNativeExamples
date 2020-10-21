
namespace XamarinNativeExamples.Core.Services.WebSocketServices.Base
{
    internal class WebSocketFactory : IWebSocketFactory
    {
        public WebSocketFactory()
        {
            WebSocketClient = new WebSocketClient();
        }

        public IWebSocketClient WebSocketClient { get; private set; }
    }
}
