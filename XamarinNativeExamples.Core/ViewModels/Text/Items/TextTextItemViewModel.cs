using System.Threading.Tasks;
using XamarinNativeExamples.Core.Properties;

namespace XamarinNativeExamples.Core.ViewModels.Text.Items
{
    public class TextTextItemViewModel: CellItemViewModel
    {
        public string Text { get; private set; }

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
