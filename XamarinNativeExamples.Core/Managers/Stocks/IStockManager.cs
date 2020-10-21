using System;
using System.Threading.Tasks;
using XamarinNativeExamples.Core.Models;

namespace XamarinNativeExamples.Core.Managers.Stocks
{
    internal interface IStockManager
    {
        event Action PingReceived;

        event Action<string> ErrorReceived;

        event Action<PriceUpdateModel> PriceUpdated;

        Task<NewsSentimentModel> GetNewsSentiment(string stockSymbol);

        Task<bool> ValidateToken(string token);

        Task<bool> TokenValidated();

        Task UpdateToken(string token);

        Task SubscribeToStock(string stockSymbol);

        Task UnsubscribeToStock(string stockSymbol);

        Task ConnectWebSocket();

        Task DisconnectWebSocket();
    }
}
