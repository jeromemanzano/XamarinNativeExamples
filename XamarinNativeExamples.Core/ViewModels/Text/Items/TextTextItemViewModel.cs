using XamarinNativeExamples.Core.Properties;

namespace XamarinNativeExamples.Core.ViewModels.Text.Items
{
    public class TextTextItemViewModel: CellItemViewModel
    {
        public override string Title => Resources.TextTextHeader;

        public string Text { get; private set; }
    }
}
