using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using XamarinNativeExamples.Core.Managers.Stocks;
using XamarinNativeExamples.Core.Models;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.Services.Interactions;
using XamarinNativeExamples.Core.ViewModels.WebSocket;

namespace XamarinNativeExamples.Core.Tests.ViewModels.WebSocket
{
    [TestFixture]
    public class WithWebSocketViewModel : BasePageViewModelTest<WebSocketViewModel>
    {
        private Mock<IStockManager> _stockManager;

        [Test]
        public async Task On_Initialize_Should_Set_Connect_Button_Text()
        {
            await ViewModel.Initialize();
            
            Assert.AreEqual(Resources.Connect, ViewModel.ConnectButtonText);
        }

        [Test]
        public async Task ConnectionCommand_Should_Call_Connect_WebSocket_Async_When_Not_Connected()
        {
            await ViewModel.ConnectionCommand.ExecuteAsync();
            
            _stockManager.Verify(manager => manager.ConnectWebSocketAsync(), Times.Once);
            Assert.AreEqual(string.Format(Resources.PingCountFormat, 0), ViewModel.PingCount);
            Assert.IsEmpty(ViewModel.Time);
            Assert.IsEmpty(ViewModel.Price);
            Assert.IsEmpty(ViewModel.Volume);
            Assert.AreEqual(Resources.Disconnect, ViewModel.ConnectButtonText);
        }
        
        [Test]
        public async Task ConnectionCommand_Should_Call_Disconnect_WebSocket_Async_When_Connected()
        {
            // Connect first
            await ViewModel.ConnectionCommand.ExecuteAsync();
            Assert.AreEqual(Resources.Disconnect, ViewModel.ConnectButtonText);
            
            _stockManager.Invocations.Clear();

            await ViewModel.ConnectionCommand.ExecuteAsync();
            _stockManager.Verify(manager => manager.DisconnectWebSocketAsync(), Times.Once);
            Assert.AreEqual(Resources.Connect, ViewModel.ConnectButtonText);
            Assert.IsEmpty(ViewModel.PingCount);
            Assert.IsEmpty(ViewModel.InputStockSymbol);
        }

        [Test]
        public async Task ConnectionCommand_Should_Show_WebSocketExceptionMessage_When_ConnectWebSocket_Throws_WebSocketException()
        {
            _stockManager.Setup(manager => manager.ConnectWebSocketAsync()).ThrowsAsync(new WebSocketException());
            
            await ViewModel.ConnectionCommand.ExecuteAsync();

            InteractionManager.Verify(manager => manager.ShowDialogAsync(Resources.WebSocketExceptionMessage, null, null), Times.Once);
        }
        
        [Test]
        public async Task ConnectionCommand_Should_Show_UnknownErrorMessage_When_ConnectWebSocket_Throws_Exception()
        {
            _stockManager.Setup(manager => manager.ConnectWebSocketAsync()).ThrowsAsync(new Exception());
            
            await ViewModel.ConnectionCommand.ExecuteAsync();

            InteractionManager.Verify(manager => manager.ShowDialogAsync(Resources.UnknownErrorMessage, null, null), Times.Once);
        }

        [Test]
        public async Task SubscribeCommand_Should_Execute_SubscribeToStock()
        {
            var stockSymbol = "a";
            ViewModel.InputStockSymbol = stockSymbol;
            await ViewModel.SubscribeCommand.ExecuteAsync();
            
            _stockManager.Verify(manager => manager.SubscribeToStockAsync(stockSymbol), Times.Once);
        }

        [Test]
        public async Task When_Disconnecting_Should_Not_Throw_Exception_When_DisconnectWebSocket_Throws_Exception()
        {
            // Connect first
            await ViewModel.ConnectionCommand.ExecuteAsync();
            Assert.AreEqual(Resources.Disconnect, ViewModel.ConnectButtonText);

            _stockManager.Setup(manager => manager.DisconnectWebSocketAsync()).Throws(new Exception());
           
            Assert.DoesNotThrow(() => ViewModel.ConnectionCommand.ExecuteAsync());
            InteractionManager.VerifyNoOtherCalls();
        }

        [Test]
        public void On_Price_Updated_Should_Update_Time_Volume_Price()
        {
            var priceModel = new PriceUpdateModel()
            {
                Price = 1,
                Symbol = "a",
                Time = DateTime.Now,
                Volume = 1
            };
            
            _stockManager.Raise(manager => manager.PriceUpdated += null, priceModel);
            
            Assert.AreEqual(string.Format(Resources.TimeFormat, priceModel.Time), ViewModel.Time);
            Assert.AreEqual(string.Format(Resources.VolumeFormat, priceModel.Volume), ViewModel.Volume);
            Assert.AreEqual(string.Format(Resources.PriceFormat, priceModel.Price), ViewModel.Price);
        }
        
        [Test]
        public void On_PingReceived_Should_PingCount()
        {
            for (int i = 1; i < 10; i++)
            {
                _stockManager.Raise(manager => manager.PingReceived += null);
            
                Assert.AreEqual(string.Format(Resources.PingCountFormat, i), ViewModel.PingCount);
            }
        }
        
        [Test]
        public void On_Error_Received_Should_Show_Error_As_Notification()
        {
            var errorMessage = "error message";
            _stockManager.Raise(manager => manager.ErrorReceived += null, errorMessage);
            
            InteractionManager.Verify(manager => manager.ShowNotification(errorMessage, NotificationLength.Long));
        }
        
        protected override WebSocketViewModel CreateViewModel()
        {
            _stockManager = new Mock<IStockManager>();
            return new WebSocketViewModel(null, NavigationService.Object, _stockManager.Object, InteractionManager.Object);
        }
    }
}