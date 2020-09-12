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

        private string _header;
        public string Header
        {
            get => _header;
            private set => SetProperty(ref _header, value);
        }

        private string _regex;
        public string Regex
        {
            get => _regex;
            private set => SetProperty(ref _regex, value);
        }
    }
}
