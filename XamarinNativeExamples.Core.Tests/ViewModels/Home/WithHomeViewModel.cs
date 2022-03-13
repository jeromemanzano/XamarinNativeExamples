using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using XamarinNativeExamples.Core.Managers.Stocks;
using XamarinNativeExamples.Core.ViewModels.Base;
using XamarinNativeExamples.Core.ViewModels.Button;
using XamarinNativeExamples.Core.ViewModels.Home;
using XamarinNativeExamples.Core.ViewModels.Http;
using XamarinNativeExamples.Core.ViewModels.Text;
using XamarinNativeExamples.Core.ViewModels.Token;
using XamarinNativeExamples.Core.ViewModels.WebSocket;

namespace XamarinNativeExamples.Core.Tests.ViewModels.Home
{
    [TestFixture]
    public class WithHomeViewModel : BasePageViewModelTest<HomeViewModel>
    {
        private Mock<IStockManager> _stockManager;

        [Test]
        public async Task OpenButtonCommand_Should_Navigate_To_ButtonViewModel()
        {
            await ViewModel.OpenButtonCommand.ExecuteAsync();
            
            NavigationService.Verify(service => service.Navigate<ButtonViewModel>(null, default), Times.Once);
        }
        
        [Test]
        public async Task OpenTextCommand_Should_Navigate_To_TextViewModel()
        {
            await ViewModel.OpenTextCommand.ExecuteAsync();
            
            NavigationService.Verify(service => service.Navigate<TextViewModel>(null, default), Times.Once);
        }

        [Test]
        public async Task OpenRestCommand_Should_Navigate_To_HttpViewModel_When_Token_Is_Validated()
        {
            _stockManager.Setup(manager => manager.TokenValidatedAsync()).ReturnsAsync(true);
            
            await ViewModel.OpenRestCommand.ExecuteAsync();
            
            _stockManager.Verify(manager => manager.TokenValidatedAsync(), Times.Once);
            NavigationService.Verify(service => service.Navigate<HttpViewModel>(null, default), Times.Once);
        }
        
        [Test]
        public async Task OpenRestCommand_Should_Navigate_To_TokenViewModel_When_Token_Is_Not_Validated()
        {
            _stockManager.Setup(manager => manager.TokenValidatedAsync()).ReturnsAsync(false);
            
            await ViewModel.OpenRestCommand.ExecuteAsync();

            _stockManager.Verify(manager => manager.TokenValidatedAsync(), Times.Once);
            NavigationService.Verify(service => service.Navigate<TokenViewModel, NavigationResult>(null, default), Times.Once);
            NavigationService.Verify(service => service.Navigate<HttpViewModel>(null, default), Times.Never);
        }
     
        [Test]
        public async Task OpenRestCommand_Should_Navigate_To_HttpViewModel_When_Token_Is_Not_Validated_And_NavigationResult_Is_True([Values]bool success)
        {
            _stockManager.Setup(manager => manager.TokenValidatedAsync()).ReturnsAsync(false);
            NavigationService
                .Setup(service => service.Navigate<TokenViewModel, NavigationResult>(null, default))
                .ReturnsAsync(new NavigationResult(success));
            
            await ViewModel.OpenRestCommand.ExecuteAsync();
            
            NavigationService.Verify(service => service.Navigate<TokenViewModel, NavigationResult>(null, default), Times.Once);
            NavigationService.Verify(service => service.Navigate<HttpViewModel>(null, default), success ? Times.Once : Times.Never);
        }
        
        [Test]
        public async Task OpenRestCommand_Should_Not_Navigate_To_HttpViewModel_When_Token_Is_Not_Validated_And_NavigationResult_Is_Null()
        {
            _stockManager.Setup(manager => manager.TokenValidatedAsync()).ReturnsAsync(false);
            NavigationService
                .Setup(service => service.Navigate<TokenViewModel, NavigationResult>(null, default))
                .ReturnsAsync((NavigationResult)null);
            
            await ViewModel.OpenRestCommand.ExecuteAsync();
            
            NavigationService.Verify(service => service.Navigate<TokenViewModel, NavigationResult>(null, default), Times.Once);
            NavigationService.Verify(service => service.Navigate<HttpViewModel>(null, default), Times.Never);
        }
        
        [Test]
        public async Task OpenWebSocketCommand_Should_Navigate_To_WebSocketViewModel_When_Token_Is_Validated()
        {
            _stockManager.Setup(manager => manager.TokenValidatedAsync()).ReturnsAsync(true);
            
            await ViewModel.OpenWebSocketCommand.ExecuteAsync();
            
            _stockManager.Verify(manager => manager.TokenValidatedAsync(), Times.Once);
            NavigationService.Verify(service => service.Navigate<WebSocketViewModel>(null, default), Times.Once);
        }
        
        [Test]
        public async Task OpenWebSocketCommand_Should_Navigate_To_WebSocketViewModel_When_Token_Is_Not_Validated()
        {
            _stockManager.Setup(manager => manager.TokenValidatedAsync()).ReturnsAsync(false);
            
            await ViewModel.OpenWebSocketCommand.ExecuteAsync();
            
            _stockManager.Verify(manager => manager.TokenValidatedAsync(), Times.Once);
            NavigationService.Verify(service => service.Navigate<TokenViewModel, NavigationResult>(null, default), Times.Once);
            NavigationService.Verify(service => service.Navigate<WebSocketViewModel>(null, default), Times.Never);
        }
     
        [Test]
        public async Task OpenWebSocketCommand_Should_Navigate_To_WebSocketViewModel_When_Token_Is_Not_Validated_And_NavigationResult_Is_True([Values]bool success)
        {
            _stockManager.Setup(manager => manager.TokenValidatedAsync()).ReturnsAsync(false);
            NavigationService
                .Setup(service => service.Navigate<TokenViewModel, NavigationResult>(null, default))
                .ReturnsAsync(new NavigationResult(success));
            
            await ViewModel.OpenWebSocketCommand.ExecuteAsync();
            
            NavigationService.Verify(service => service.Navigate<TokenViewModel, NavigationResult>(null, default), Times.Once);
            NavigationService.Verify(service => service.Navigate<WebSocketViewModel>(null, default), success ? Times.Once : Times.Never);
        }
        
        [Test]
        public async Task OpenWebSocketCommand_Should_Not_Navigate_To_WebSocketViewModel_When_Token_Is_Not_Validated_And_NavigationResult_Is_Null()
        {
            _stockManager.Setup(manager => manager.TokenValidatedAsync()).ReturnsAsync(false);
            NavigationService
                .Setup(service => service.Navigate<TokenViewModel, NavigationResult>(null, default))
                .ReturnsAsync((NavigationResult)null);
            
            await ViewModel.OpenWebSocketCommand.ExecuteAsync();
            
            NavigationService.Verify(service => service.Navigate<TokenViewModel, NavigationResult>(null, default), Times.Once);
            NavigationService.Verify(service => service.Navigate<WebSocketViewModel>(null, default), Times.Never);
        }
        
        protected override HomeViewModel CreateViewModel()
        {
            _stockManager = new Mock<IStockManager>();
            return new HomeViewModel(null, NavigationService.Object, null, _stockManager.Object);
        }
    }
}