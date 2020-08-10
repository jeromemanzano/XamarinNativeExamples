using System.Threading.Tasks;
using MvvmCross.Commands;
using XamarinNativeExamples.Core.ViewModels.Base;
using XamarinNativeExamples.Core.ViewModels.Button;

namespace XamarinNativeExamples.Core.ViewModels.Home
{
    public class HomeViewModel : BasePageViewModel
    {
        private IMvxCommand _openButtonCommand;
        public IMvxCommand OpenButtonCommand
        {
            get => _openButtonCommand ?? (_openButtonCommand = new MvxAsyncCommand(OpenButton));
        }

        private Task OpenButton() 
        {
            return Navigation.Navigate<ButtonViewModel>();
        }
    }
}
