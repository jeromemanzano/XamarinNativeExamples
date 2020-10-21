using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XamarinNativeExamples.Core.Exceptions;
using XamarinNativeExamples.Core.Managers.Base;
using XamarinNativeExamples.Core.Models;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.Services.RestServices;
using XamarinNativeExamples.Core.Services.Storage;
using XamarinNativeExamples.Core.Services.WebSocketServices;
using XamarinNativeExamples.Core.Services.WebSocketServices.Messages.Responses;
using XamarinNativeExamples.Core.Utils.Constants;

namespace XamarinNativeExamples.Core.Managers.Stocks
{
    internal class StockManager : BaseManager, IStockManager
    {
        private readonly IStockRestService _stockRestService;
        private readonly IStockWebSocketService _stockWebSocketService;
        private readonly ISecuredStorage _securedStorage;

        public event Action PingReceived;
        public event Action<string> ErrorReceived;
        public event Action<PriceUpdateModel> PriceUpdated;

        public StockManager(IStockRestService stockRestService,
            IStockWebSocketService stockWebSocketService,
            ISecuredStorage securedStorage)
        {
            _stockRestService = stockRestService;
            _stockWebSocketService = stockWebSocketService;
            _securedStorage = securedStorage;

            _stockWebSocketService.PingReceived += OnPingReceived;
            _stockWebSocketService.ErrorReceived += OnErrorReceived;
            _stockWebSocketService.PriceUpdateReceived += OnPriceUpdateReceived;
        }

        public async Task<NewsSentimentModel> GetNewsSentiment(string stockSymbol)
        {
            var response = await _stockRestService.GetNewsSentiment(stockSymbol, await GetApiToken());
            var newsSentimentModel = Mapper.Map<NewsSentimentModel>(response);

            if (newsSentimentModel.Buzz == null)
            {
                throw new BusinessException(string.Format(Resources.StockEmptyErrorMessage, stockSymbol));
            }

            return newsSentimentModel;
        }

        public async Task<bool> ValidateToken(string token)
        {
            return await _stockRestService.ValidateTokenAsync(token);
        }

        public async Task<bool> TokenValidated()
        {
            return !(await GetApiToken()).IsNullOrEmpty();
        }

        public Task UpdateToken(string token)
        {
            return _securedStorage.SetAsync(StorageKeys.ApiToken, token);
        }

        public async Task SubscribeToStock(string stockSymbol)
        {
            await _stockWebSocketService.UpdateStockSubscription("subscribe", stockSymbol, new CancellationTokenSource(30000).Token);
        }

        public async Task UnsubscribeToStock(string stockSymbol) 
        { 
            await _stockWebSocketService.UpdateStockSubscription("unsubscribe", stockSymbol, new CancellationTokenSource(30000).Token);
        }

        public async Task ConnectWebSocket()
        {
            await _stockWebSocketService.EnsureConnectionOpen(await GetApiToken());
        }

        public async Task DisconnectWebSocket()
        {
            await _stockWebSocketService.Disconnect();
        }

        private Task<string> GetApiToken() 
        { 
            return _securedStorage.GetAsync(StorageKeys.ApiToken);
        }

        private void OnPriceUpdateReceived(PriceUpdateMessageResponse response)
        {
            var priceUpdateModel = Mapper.Map<PriceUpdateModel>(response.Data.First());

            PriceUpdated?.Invoke(priceUpdateModel);
        }

        private void OnErrorReceived(string errorMessage)
        {
            ErrorReceived?.Invoke(errorMessage);
        }

        private void OnPingReceived()
        {
            PingReceived?.Invoke();
        }
    }
}
