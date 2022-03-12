using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using XamarinNativeExamples.Core.Properties;

namespace XamarinNativeExamples.Core.ViewModels.Text.Items
{
    public class TextFilterItemViewModel : CellItemViewModel
    {
        public override string Title => Resources.TextFilterHeader;
        public override string Description => Resources.TextFilterDescription;
        public string InputText { get; private set; }
        public string Regex { get; private set; }
        
        private IMvxCommand _filterSelectedCommand;
        public IMvxCommand FilterSelectedCommand => _filterSelectedCommand ??= new MvxCommand<FilterItemViewModel>(FilterSelected);

        public MvxObservableCollection<FilterItemViewModel> Filters { get; } = new ()
        {
            new FilterItemViewModel(Resources.TextFilterNumber, @"^[0-9]*$"),
            new FilterItemViewModel(Resources.TextFilterLowerCase, @"^[a-z]*$")
        };

        private void FilterSelected(FilterItemViewModel item)
        {
            Regex = item.Regex;
            InputText = null;
        }
    }
}
