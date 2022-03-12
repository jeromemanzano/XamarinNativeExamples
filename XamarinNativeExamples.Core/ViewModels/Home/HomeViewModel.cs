using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
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

        public HomeViewModel() 
        { 
            _stockManager = Mvx.IoCProvider.Resolve<IStockManager>();
        }
        
        private Task OpenButtonAsync() 
        {
            return Navigation.Navigate<ButtonViewModel>();
        }

        private Task OpenTextAsync()
        {
            return Navigation.Navigate<TextViewModel>();
        }

        private async Task OpenRestAsync() 
        {
            if (!await _stockManager.TokenValidatedAsync())
            {
                var validated = await Navigation.Navigate<TokenViewModel>();

                if (!validated)
                {
                    return;
                }
            }

            await Navigation.Navigate<HttpViewModel>();
        }

        private async Task OpenWebSocketAsync()
        {
            if (!(await _stockManager.TokenValidatedAsync()))
            {
                var validated = await Navigation.Navigate<TokenViewModel>();

                if (!validated)
                {
                    return;
                }
            }

            await Navigation.Navigate<WebSocketViewModel>();
        }
    }
}
