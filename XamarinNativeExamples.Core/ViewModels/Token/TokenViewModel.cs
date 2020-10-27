using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using XamarinNativeExamples.Core.Managers.Stocks;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.ViewModels.Base;

namespace XamarinNativeExamples.Core.ViewModels.Token
{
    public class TokenViewModel : BaseResultPageViewModel<bool>
    {
        private readonly IStockManager _stockManager;

        public TokenViewModel() 
        { 
            _stockManager = Mvx.IoCProvider.Resolve<IStockManager>();
        }

        public override Task Initialize()
        {
            TestButtonText = Resources.Test;
            ApiTextEnabled = true;

            return base.Initialize();
        }

        public override string Title => string.Empty;

        public string TokenStartText => Resources.TokenStartMessage;

        public string TokenRegisterText => Resources.TokenRegisterMessage;

        public string TokenCopyText => Resources.TokenCopyMessage;

        public string TokenTestText => Resources.TokenTestMessage;

        public string TokenNextText => Resources.Next;

        public string ApiKeyPlaceholder => Resources.ApiKeyPlaceholder;

        public string TokenFailedText => Resources.TokenFailedMessage;

        public string TokenSuccessText => Resources.TokenSuccessMessage;

        private string _testButtonText;
        public string TestButtonText
        {
            get => _testButtonText;
            private set => SetProperty(ref _testButtonText, value);
        }

        private string _apiToken;
        public string ApiToken
        {
            get => _apiToken;
            private set => SetProperty(ref _apiToken, value);
        }

        private bool _tokenValid;
        public bool TokenValid
        {
            get => _tokenValid;
            private set => SetProperty(ref _tokenValid, value);
        }

        private bool _tokenTested;
        public bool TokenTested
        {
            get => _tokenTested;
            private set => SetProperty(ref _tokenTested, value);
        }

        private bool _apiTextEnabled;
        public bool ApiTextEnabled
        {
            get => _apiTextEnabled;
            private set => SetProperty(ref _apiTextEnabled, value);
        }

        private bool _showFailed;
        public bool ShowFailed
        {
            get => _showFailed;
            private set => SetProperty(ref _showFailed, value);
        }

        private bool _showSuccess;
        public bool ShowSuccess
        {
            get => _showSuccess;
            private set => SetProperty(ref _showSuccess, value);
        }

        private IMvxCommand _saveCommand;
        public IMvxCommand SaveCommand
        {
            get => _saveCommand ?? (_saveCommand = new MvxAsyncCommand(Save));
        }

        private async Task Save()
        {
            if (TokenValid)
            {
                await _stockManager.UpdateToken(ApiToken);
                await Navigation.Close<bool>(this, true);
            }
            else 
            {
                TokenValid = await _stockManager.ValidateToken(ApiToken);
                TestButtonText = TokenValid ? Resources.Save : Resources.Test;
                ApiTextEnabled = !TokenValid;
                ShowSuccess = TokenValid;
                ShowFailed = !TokenValid;
            }

            TokenTested = true;
        }
    }
}
