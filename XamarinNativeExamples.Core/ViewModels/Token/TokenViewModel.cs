using System.Threading.Tasks;
using MvvmCross.Commands;
using XamarinNativeExamples.Core.Managers.Stocks;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.ViewModels.Base;

namespace XamarinNativeExamples.Core.ViewModels.Token
{
    public class TokenViewModel : BaseResultPageViewModel<bool>
    {
        private readonly IStockManager _stockManager;
        public override string Title => string.Empty;
        public string TokenStartText => Resources.TokenStartMessage;
        public string TokenRegisterText => Resources.TokenRegisterMessage;
        public string TokenCopyText => Resources.TokenCopyMessage;
        public string TokenTestText => Resources.TokenTestMessage;
        public string TokenNextText => Resources.Next;
        public string ApiKeyPlaceholder => Resources.ApiKeyPlaceholder;

        public string TokenFailedText => Resources.TokenFailedMessage;

        public string TokenSuccessText => Resources.TokenSuccessMessage;
        public string TestButtonText { get; private set; }
        public string ApiToken { get; private set; }
        public bool TokenValid { get; private set; }
        public bool TokenTested { get; private set; }
        public bool ApiTextEnabled { get; private set; }
        public bool ShowFailed { get; private set; }
        public bool ShowSuccess { get; private set; }

        private IMvxCommand _saveCommand;
        public IMvxCommand SaveCommand => _saveCommand ??= new MvxAsyncCommand(SaveAsync);

        public TokenViewModel() 
        { 
            _stockManager = IoCProvider.Resolve<IStockManager>();
        }

        public override Task Initialize()
        {
            TestButtonText = Resources.Test;
            ApiTextEnabled = true;

            return base.Initialize();
        }
        
        private async Task SaveAsync()
        {
            if (TokenValid)
            {
                await _stockManager.UpdateTokenAsync(ApiToken);
                await Navigation.Close(this);
            }
            else 
            {
                TokenValid = await _stockManager.ValidateTokenAsync(ApiToken);
                TestButtonText = TokenValid ? Resources.Save : Resources.Test;
                ApiTextEnabled = !TokenValid;
                ShowSuccess = TokenValid;
                ShowFailed = !TokenValid;
            }

            TokenTested = true;
        }
    }
}
