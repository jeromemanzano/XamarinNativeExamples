using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.ViewModels;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.ViewModels.Base;
using XamarinNativeExamples.Core.ViewModels.Text.Items;

namespace XamarinNativeExamples.Core.ViewModels.Text
{
    public class TextViewModel : BasePageViewModel
    {
        public override string Title => Resources.TextTitle;

        private readonly IMvxViewModelLoader _viewModelLoader;

        public TextViewModel()
        {
            _viewModelLoader = Mvx.IoCProvider.Resolve<IMvxViewModelLoader>();
        }

        public IMvxViewModel TextText { get; private set; }

        public IMvxViewModel TextFilter { get; private set; }

        public override Task Initialize()
        {
            var textTextRequest = new MvxViewModelRequest(typeof(TextTextItemViewModel));
            TextText = _viewModelLoader.LoadViewModel(textTextRequest, null);

            var textFilter = new MvxViewModelRequest(typeof(TextFilterItemViewModel));
            TextFilter = _viewModelLoader.LoadViewModel(textFilter, null);

            return base.Initialize();
        }
    }
}
