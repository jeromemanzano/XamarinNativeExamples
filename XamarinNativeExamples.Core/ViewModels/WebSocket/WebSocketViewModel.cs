using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using XamarinNativeExamples.Core.Managers.Interactions;
using XamarinNativeExamples.Core.Managers.Stocks;
using XamarinNativeExamples.Core.Models;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.Services.Interactions;
using XamarinNativeExamples.Core.ViewModels.Base;

namespace XamarinNativeExamples.Core.ViewModels.WebSocket
{
    public class WebSocketViewModel : BasePageViewModel
    {
        private readonly IStockManager _stockManager;
        private string _currentStockSymbol;
        private bool _connected;
        private int _ping;

        public override string Title => string.Empty;
        public string SubscribeText => Resources.Subscribe;
        public string Price { get; private set; }
        public string Volume { get; private set; }
        public string Time { get; private set; }
        public string PingCount { get; private set; }
        public string ConnectButtonText { get; private set; }
        public bool SubscribeEnabled { get; private set; }
        public bool ShowStockDetails { get; private set; }

        private string _inputStockSymbol;
        public string InputStockSymbol
        {
            get => _inputStockSymbol;
            private set
            {
                SetProperty(ref _inputStockSymbol, value);
                SubscribeEnabled = _currentStockSymbol != value;
            }
        }
        
        private IMvxCommand _connectionCommand;
        public IMvxCommand ConnectionCommand => _connectionCommand ??= new MvxAsyncCommand(UpdateConnectionAsync);

        private IMvxCommand _subscribeCommand;
        public IMvxCommand SubscribeCommand => _subscribeCommand ??= new MvxAsyncCommand(SubscribeAsync);
        
        public WebSocketViewModel(ILoggerFactory loggerFactory, 
            IMvxNavigationService navigationService,
            IStockManager stockManager,
            IInteractionManager interactionManager)
            :base(loggerFactory, navigationService, interactionManager)
        {
            _stockManager = stockManager;
            _stockManager.ErrorReceived += OnError;
            _stockManager.PingReceived += OnPing;
            _stockManager.PriceUpdated += OnPriceUpdate;
        }
        
        public override Task Initialize()
        {
            _currentStockSymbol = string.Empty;
            _connected = false;
            _ping = 0;
            ConnectButtonText = Resources.Connect;

            return base.Initialize();
        }

        public override async void ViewDisappearing()
        {
            base.ViewDisappearing();

            if (_connected)
            {
                await UpdateConnectionAsync();
                _stockManager.ErrorReceived -= OnError;
                _stockManager.PingReceived -= OnPing;
                _stockManager.PriceUpdated -= OnPriceUpdate;
            }
        }

        private async Task UpdateConnectionAsync()
        {

            if (_connected)
            {
                await UnsubscribeCurrent();
                await _stockManager.DisconnectWebSocketAsync();
                ConnectButtonText = Resources.Connect;
                PingCount = string.Empty;
                InputStockSymbol = string.Empty;
            }
            else 
            {
                await _stockManager.ConnectWebSocketAsync();
                _ping = 0;
                PingCount = string.Format(Resources.PingCountFormat, 0);
                Time = string.Empty;
                Price = string.Empty;
                Volume = string.Empty;
                ConnectButtonText = Resources.Disconnect;
            }

            _connected = !_connected;
            ShowStockDetails = _connected;
        }

        private async Task SubscribeAsync() 
        {
            await UnsubscribeCurrent();
            await _stockManager.SubscribeToStockAsync(InputStockSymbol);
            _currentStockSymbol = InputStockSymbol;
        }

        private async Task UnsubscribeCurrent() 
        {
            if (!_currentStockSymbol.IsNullOrEmpty())
            {
                await _stockManager.UnsubscribeToStockAsync(_currentStockSymbol);
                _currentStockSymbol = string.Empty;
            }
        }

        private void OnPriceUpdate(PriceUpdateModel priceUpdate)
        {
            InvokeOnMainThread(() => 
            {
                Time = string.Format(Resources.TimeFormat, priceUpdate.Time);
                Volume = string.Format(Resources.VolumeFormat, priceUpdate.Volume);
                Price = string.Format(Resources.PriceFormat, priceUpdate.Price);
            });
        }

        private void OnError(string message)
        {
            InvokeOnMainThread(() =>
            {
                Interactions.ShowNotification(message, NotificationLength.Long);
            });
        }

        private void OnPing()
        {
            _ping++;

            InvokeOnMainThread(() =>
            {
                PingCount = string.Format(Resources.PingCountFormat, _ping);
            });
        }
    }
}
