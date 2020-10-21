using System;
using System.Threading;
using System.Threading.Tasks;
using XamarinNativeExamples.Core.Services.WebSocketServices.Base;
using XamarinNativeExamples.Core.Services.WebSocketServices.Messages.Responses;

namespace XamarinNativeExamples.Core.Services.WebSocketServices
{
    internal interface IStockWebSocketService : IBaseWebSocketService
    {
        event Action<PriceUpdateMessageResponse> PriceUpdateReceived;

        Task UpdateStockSubscription(string type, string stockSymbol, CancellationToken token);
    }
}
