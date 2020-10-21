using System;
using System.Threading;
using System.Threading.Tasks;
using XamarinNativeExamples.Core.Services.WebSocketServices.Base;
using XamarinNativeExamples.Core.Services.WebSocketServices.Messages.Requests;
using XamarinNativeExamples.Core.Services.WebSocketServices.Messages.Responses;

namespace XamarinNativeExamples.Core.Services.WebSocketServices
{
    internal class StockWebSocketService : BaseWebSocketService, IStockWebSocketService
    {
        public event Action<PriceUpdateMessageResponse> PriceUpdateReceived;

        public StockWebSocketService(IWebSocketFactory webSocketFactory) 
            : base(webSocketFactory)
        {
        }

        public Task UpdateStockSubscription(string type, string stockSymbol, CancellationToken token)
        {
            var request = new SubscriptionMessageRequest()
            {
                Type = type,
                Symbol = stockSymbol
            };

            return SendMessage(request, token);
        }

        protected override void HandleMessage(string type, string jsonMessage)
        {
            base.HandleMessage(type, jsonMessage);
    
            if (type == "trade")
            {
                PriceUpdateReceived?.Invoke(Deserialize<PriceUpdateMessageResponse>(jsonMessage));
            }
        }
    }
}
