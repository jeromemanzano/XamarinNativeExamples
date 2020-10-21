using System;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
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

        public WebSocketViewModel()
        {
            _stockManager = Mvx.IoCProvider.Resolve<IStockManager>();
            _stockManager.ErrorReceived += OnError;
            _stockManager.PingReceived += OnPing;
            _stockManager.PriceUpdated += OnPriceUpdate;
        }

        private IMvxCommand _connectionCommand;
        public IMvxCommand ConnectionCommand
        {
            get => _connectionCommand ?? (_connectionCommand = new MvxAsyncCommand(UpdateConnection));
        }

        private IMvxCommand _subscribeCommand;
        public IMvxCommand SubscribeCommand
        {
            get => _subscribeCommand ?? (_subscribeCommand = new MvxAsyncCommand(Subscribe));
        }

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

        private string _price;
        public string Price
        {
            get => _price;
            private set => SetProperty(ref _price, value);
        }

        private string _volume;
        public string Volume
        {
            get => _volume;
            private set => SetProperty(ref _volume, value);
        }

        private string _time;
        public string Time
        {
            get => _time;
            private set => SetProperty(ref _time, value);
        }

        private string _pingCount;
        public string PingCount
        {
            get => _pingCount;
            private set => SetProperty(ref _pingCount, value);
        }

        private string _connectButtonText;
        public string ConnectButtonText
        {
            get => _connectButtonText;
            private set => SetProperty(ref _connectButtonText, value);
        }

        private bool _subscribeEnabled;
        public bool SubscribeEnabled
        {
            get => _subscribeEnabled;
            private set => SetProperty(ref _subscribeEnabled, value);
        }

        private bool _showStockDetails;
        public bool ShowStockDetails
        {
            get => _showStockDetails;
            private set => SetProperty(ref _showStockDetails, value);
        }

        public string SubscribeText => Resources.Subscribe;

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
                await UpdateConnection();
            }
        }

        private async Task UpdateConnection()
        {

            if (_connected)
            {
                await UnsubscribeCurrent();
                await _stockManager.DisconnectWebSocket();
                ConnectButtonText = Resources.Connect;
                PingCount = string.Empty;
                InputStockSymbol = string.Empty;
            }
            else 
            {
                await _stockManager.ConnectWebSocket();
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

        private async Task Subscribe() 
        {
            await UnsubscribeCurrent();
            await _stockManager.SubscribeToStock(InputStockSymbol);
            _currentStockSymbol = InputStockSymbol;
        }

        private async Task UnsubscribeCurrent() 
        {
            if (!_currentStockSymbol.IsNullOrEmpty())
            {
                await _stockManager.UnsubscribeToStock(_currentStockSymbol);
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
