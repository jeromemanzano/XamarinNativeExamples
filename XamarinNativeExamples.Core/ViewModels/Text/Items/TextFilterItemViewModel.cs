using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using XamarinNativeExamples.Core.Properties;

namespace XamarinNativeExamples.Core.ViewModels.Text.Items
{
    public class TextFilterItemViewModel : CellItemViewModel
    {
        private IMvxCommand _filterSelectedCommand;
        public IMvxCommand FilterSelectedCommand
        {
            get => _filterSelectedCommand ?? (_filterSelectedCommand = new MvxCommand<FilterItemViewModel>(FilterSeleted));
        }

        public MvxObservableCollection<FilterItemViewModel> Filters { get; } = new MvxObservableCollection<FilterItemViewModel>();

        public string InputText { get; private set; }
        public string Regex { get; private set; }

        public override Task Initialize()
        {
            InvokeOnMainThread(() =>
            {
                Title = Resources.TextFilterHeader;
                Description = Resources.TextFilterDescription;
                Filters.Add(new FilterItemViewModel(Resources.TextFilterNumber, @"^[0-9]*$"));
                Filters.Add(new FilterItemViewModel(Resources.TextFilterLowerCase, @"^[a-z]*$"));
            });

            return base.Initialize();
        }

        private void FilterSeleted(FilterItemViewModel item)
        {
            Regex = item.Regex;
            InputText = null;
        }
    }
}
