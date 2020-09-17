using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.ViewModels;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.ViewModels.Base;
using XamarinNativeExamples.Core.ViewModels.Button.Items;

namespace XamarinNativeExamples.Core.ViewModels.Button
{
    public class ButtonViewModel : BasePageViewModel
    {
        public override string Title => Resources.ButtonTitle;

        private readonly IMvxViewModelLoader _viewModelLoader;

        public ButtonViewModel()
        {
            _viewModelLoader = Mvx.IoCProvider.Resolve<IMvxViewModelLoader>();
        }

        public IMvxViewModel ButtonClick { get; private set; }

        public IMvxViewModel ButtonEnable { get; private set; }

        public override Task Initialize()
        {
            var buttonClickRequest = new MvxViewModelRequest(typeof(ButtonClickItemViewModel));
            ButtonClick = _viewModelLoader.LoadViewModel(buttonClickRequest, null);

            var buttonEnableRequest = new MvxViewModelRequest(typeof(ButtonEnableItemViewModel));
            ButtonEnable = _viewModelLoader.LoadViewModel(buttonEnableRequest, null);

            return base.Initialize();
        }
    }
}
