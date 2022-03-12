using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinNativeExamples.Core.Services.WebSocketServices.Messages.Requests;
using XamarinNativeExamples.Core.Services.WebSocketServices.Messages.Responses;
using XamarinNativeExamples.Core.Utils.Constants;

namespace XamarinNativeExamples.Core.Services.WebSocketServices.Base
{
    internal abstract class BaseWebSocketService : IBaseWebSocketService
    {
        private readonly IWebSocketClient _webSocketClient;
        private CancellationTokenSource _cts;

        public event Action<string> ErrorReceived;
        public event Action PingReceived;

        protected BaseWebSocketService(IWebSocketFactory webSocketFactory)
        {
            _webSocketClient = webSocketFactory.WebSocketClient;
        }

        protected virtual string BaseAddress { get; } = ApiConstants.StocksWebSocketUri;

        public async Task EnsureConnectionOpen(string apiToken) 
        {
            if (_webSocketClient.State != WebSocketClientState.Open)
            {
                _cts?.Cancel();
                _cts = new CancellationTokenSource(30000);

                var uri = string.Format(BaseAddress, apiToken);
                await _webSocketClient.Connect(uri, CancellationToken.None).ConfigureAwait(false);

                _webSocketClient.MessageReceived += OnMessageReceived;
            }
        }

        public Task Disconnect() 
        {
            return _webSocketClient.Disconnect();
        }

        protected Task SendMessage(SocketMessageRequest request, CancellationToken token) 
        {
            var message = JsonConvert.SerializeObject(request);
            return _webSocketClient.Send(message, token);
        }

        protected virtual void HandleMessage(string type, string jsonMessage) 
        { 
        }

        protected T Deserialize<T>(string message) where T : SocketMessageResponse
        {
            return JsonConvert.DeserializeObject<T>(message);
        }

        private void OnMessageReceived(string jsonMessage)
        {
            var message = Deserialize<SocketMessageResponse>(jsonMessage);
            if (message.Type == "error")
            {
                var errorMessage = Deserialize<ErrorMessageResponse>(jsonMessage);
                ErrorReceived?.Invoke(errorMessage.Message);
            }
            else if (message.Type == "ping")
            {
                PingReceived?.Invoke();
            }
            else
            {
                HandleMessage(message.Type, jsonMessage);
            }
        }
    }
}
