using System;
using System.Threading.Tasks;

namespace XamarinNativeExamples.Core.Services.WebSocketServices.Base
{
    internal interface IBaseWebSocketService
    {
        event Action<string> ErrorReceived;
        event Action PingReceived;
        Task EnsureConnectionOpen(string apiToken);
        Task Disconnect();
    }
}
