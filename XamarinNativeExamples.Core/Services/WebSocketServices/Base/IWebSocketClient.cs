using System;
using System.Threading;
using System.Threading.Tasks;

namespace XamarinNativeExamples.Core.Services.WebSocketServices.Base
{
    internal interface IWebSocketClient
    {
        event Action<string> MessageReceived;

        WebSocketClientState State { get; }

        Task Connect(string uriString, CancellationToken ct);

        Task Disconnect();

        Task Send(string message, CancellationToken ct);
    }

    public enum WebSocketClientState 
    {
        None = 0,
        Connecting = 1,
        Open = 2,
        CloseSent = 3,
        CloseReceived = 4,
        Closed = 5,
        Aborted = 6
    }
}
