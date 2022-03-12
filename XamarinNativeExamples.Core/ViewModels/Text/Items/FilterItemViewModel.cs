using XamarinNativeExamples.Core.ViewModels.Base;

namespace XamarinNativeExamples.Core.ViewModels.Text.Items
{
    public class FilterItemViewModel : BaseItemViewModel
    {
        public FilterItemViewModel(string header, string regex)
        {
            Header = header;
            Regex = regex;
        }

        public string Header { get; private set; }
        public string Regex { get; private set; }
    }
}
