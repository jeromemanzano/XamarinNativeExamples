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

        Task<NewsSentimentModel> GetNewsSentimentAsync(string stockSymbol);

        Task<bool> ValidateTokenAsync(string token);

        Task<bool> TokenValidatedAsync();

        Task UpdateTokenAsync(string token);

        Task SubscribeToStockAsync(string stockSymbol);

        Task UnsubscribeToStockAsync(string stockSymbol);

        Task ConnectWebSocketAsync();

        Task DisconnectWebSocketAsync();
    }
}
