using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using XamarinNativeExamples.Core.Managers.Interactions;
using XamarinNativeExamples.Core.Managers.Stocks;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.ViewModels.Base;
using XamarinNativeExamples.Core.ViewModels.Button;
using XamarinNativeExamples.Core.ViewModels.Http;
using XamarinNativeExamples.Core.ViewModels.Text;
using XamarinNativeExamples.Core.ViewModels.Token;
using XamarinNativeExamples.Core.ViewModels.WebSocket;

namespace XamarinNativeExamples.Core.ViewModels.Home
{
    public class HomeViewModel : BasePageViewModel
    {
        private readonly IStockManager _stockManager;
        
        public override string Title => Resources.HomeTitle;
        public string ButtonTitle => Resources.ButtonTitle;
        public string TextTitle => Resources.TextTitle;
        public string RestTitle => Resources.RestTitle;
        public string UserInterfaceHeader => Resources.UserInterfaceHeader;
        public string ConnectivityHeader => Resources.ConnectivityHeader;

        private IMvxCommand _openButtonCommand;
        public IMvxCommand OpenButtonCommand => _openButtonCommand ??= new MvxAsyncCommand(OpenButtonAsync);

        private IMvxCommand _openTextCommand;
        public IMvxCommand OpenTextCommand => _openTextCommand ??= new MvxAsyncCommand(OpenTextAsync);
        
        private IMvxCommand _openRestCommand;
        public IMvxCommand OpenRestCommand => _openRestCommand ??= new MvxAsyncCommand(OpenRestAsync);
        
        private IMvxCommand _openWebSocketCommand;
        public IMvxCommand OpenWebSocketCommand => _openWebSocketCommand ??= new MvxAsyncCommand(OpenWebSocketAsync);

        public HomeViewModel(ILoggerFactory loggerFactory, 
            IMvxNavigationService navigationService,
            IInteractionManager interactionManager,
            IStockManager stockManager)
            :base(loggerFactory, navigationService, interactionManager)
        {
            _stockManager = stockManager;
        }
        
        private Task OpenButtonAsync() 
        {
            return NavigationService.Navigate<ButtonViewModel>();
        }

        private Task OpenTextAsync()
        {
            return NavigationService.Navigate<TextViewModel>();
        }

        private async Task OpenRestAsync()
        {
            await NavigateIfTokenIsValidAsync<HttpViewModel>();
        }
        private async Task OpenWebSocketAsync()
        {
            await NavigateIfTokenIsValidAsync<WebSocketViewModel>();
        }
        
        private async Task NavigateIfTokenIsValidAsync<TViewModel>() where TViewModel : BasePageViewModel
        {
            if (!await _stockManager.TokenValidatedAsync())
            {
                var result = await NavigationService.Navigate<TokenViewModel, NavigationResult>();

                if (!result?.Success ?? true)
                    return;
            }

            await NavigationService.Navigate<TViewModel>();
        }

        private async Task<bool> TokenValidatedAsnyc()
        {
            if (!await _stockManager.TokenValidatedAsync())
            {
                var result = await NavigationService.Navigate<TokenViewModel, NavigationResult>();

                return result?.Success == true;
            }

            return true;
        }
    }
}
