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

        public HomeViewModel() 
        { 
            _stockManager = Mvx.IoCProvider.Resolve<IStockManager>();
        }

        public override string Title => Resources.HomeTitle;
        public string ButtonTitle => Resources.ButtonTitle;
        public string TextTitle => Resources.TextTitle;
        public string RestTitle => Resources.RestTitle;
        public string UserInterfaceHeader => Resources.UserInterfaceHeader;
        public string ConnectivityHeader => Resources.ConnectivityHeader;

        private IMvxCommand _openButtonCommand;
        public IMvxCommand OpenButtonCommand
        {
            get => _openButtonCommand ?? (_openButtonCommand = new MvxAsyncCommand(OpenButton));
        }

        private IMvxCommand _openTextCommand;
        public IMvxCommand OpenTextCommand
        {
            get => _openTextCommand ?? (_openTextCommand = new MvxAsyncCommand(OpenText));
        }

        private IMvxCommand _openRestCommand;
        public IMvxCommand OpenRestCommand
        {
            get => _openRestCommand ?? (_openRestCommand = new MvxAsyncCommand(OpenRest));
        }

        private IMvxCommand _openWebSocketCommand;
        public IMvxCommand OpenWebSocketCommand
        {
            get => _openWebSocketCommand ?? (_openWebSocketCommand = new MvxAsyncCommand(OpenWebSocket));
        }

        private Task OpenButton() 
        {
            return Navigation.Navigate<ButtonViewModel>();
        }

        private Task OpenText()
        {
            return Navigation.Navigate<TextViewModel>();
        }

        private async Task OpenRest() 
        {
            if (!(await _stockManager.TokenValidated()))
            {
                var validated = await Navigation.Navigate<TokenViewModel>();

                if (!validated)
                {
                    return;
                }
            }

            await Navigation.Navigate<HttpViewModel>();
        }

        private async Task OpenWebSocket()
        {
            if (!(await _stockManager.TokenValidated()))
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
