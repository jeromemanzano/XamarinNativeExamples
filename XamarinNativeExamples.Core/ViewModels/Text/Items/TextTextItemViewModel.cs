using System.Threading.Tasks;
using XamarinNativeExamples.Core.Properties;

namespace XamarinNativeExamples.Core.ViewModels.Text.Items
{
    public class TextTextItemViewModel: CellItemViewModel
    {
        private string _text;
        public string Text
        {
            get => _text;
            private set => SetProperty(ref _text, value);
        }

        public override Task Initialize()
        {
            InvokeOnMainThread(() =>
            {
                Title = Resources.TextTextHeader;
            });

            return base.Initialize();
        }
    }
}
