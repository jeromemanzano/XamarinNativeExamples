using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XamarinNativeExamples.Core.Services.WebSocketServices.Base
{
    internal class WebSocketClient : IWebSocketClient
    {
        private ClientWebSocket _client;
        private bool _initialized;
        private List<string> _connections = new List<string>();

        public event Action<string> MessageReceived;

        public WebSocketClient()
        {
            _client = new ClientWebSocket();
        }

        public WebSocketClientState State => (WebSocketClientState)_client.State;

        public async Task Connect(string uriString, CancellationToken ct)
        {
            if (!_connections.Contains(uriString))
            {
                await _client.ConnectAsync(new Uri(uriString), ct);
                _connections.Add(uriString);
            }

            if (!_initialized)
            {
                _initialized = true;
                await Task.Factory.StartNew(async () =>
                {
                    while (_client.State == WebSocketState.Open)
                    {
                        await ReadMessage();
                    }
                }, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            }
        }

        public Task Disconnect() 
        {
            return _client.CloseAsync(WebSocketCloseStatus.NormalClosure, "1", CancellationToken.None);
        }

        public Task Send(string message, CancellationToken ct) 
        {
            var byteMessage = Encoding.UTF8.GetBytes(message);
            var segment = new ArraySegment<byte>(byteMessage);

            return _client.SendAsync(segment, WebSocketMessageType.Text, true, ct);
        }

        private async Task ReadMessage()
        {
            WebSocketReceiveResult result;
            var message = new ArraySegment<byte>(new byte[4096]);
            do
            {
                result = await _client.ReceiveAsync(message, CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    _initialized = false;
                    _connections = new List<string>();

                    _client.Dispose();
                    _client = new ClientWebSocket();
                    break;
                }
                else if (result.MessageType == WebSocketMessageType.Text)
                {
                    var messageBytes = message.Skip(message.Offset).Take(result.Count).ToArray();
                    string receivedMessage = Encoding.UTF8.GetString(messageBytes);

                    MessageReceived?.Invoke(receivedMessage);
                }
            }
            while (!result.EndOfMessage);
        }
    }
}
