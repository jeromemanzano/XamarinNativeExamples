using System.Threading.Tasks;
using MvvmCross.Commands;
using XamarinNativeExamples.Core.Properties;

namespace XamarinNativeExamples.Core.ViewModels.Button.Items
{
    public class ButtonClickItemViewModel : CellItemViewModel
    {
        private IMvxCommand _clickCommand;
        public IMvxCommand ClickCommand
        {
            get => _clickCommand ?? (_clickCommand = new MvxCommand(ProcessClick));
        }

        private IMvxCommand _longClickCommand;
        public IMvxCommand LongClickCommand => _longClickCommand ??= new MvxCommand(ProcessLongClick);

        public int ClickCount { get; private set; }

        public int LongClickCount { get; private set; }

        public string ButtonText => Resources.TryMe;

        public string LongClickLabel => Resources.LongClickCountLabel;

        public string ClickLabel => Resources.ClickCountLabel;

        public override Task Initialize()
        {
            InvokeOnMainThread(() =>
            {
                Title = Resources.ButtonClickHeader;
            });

            return base.Initialize();
        }

        private void ProcessClick()
        {
            InvokeOnMainThread(() => ClickCount++);
        }

        private void ProcessLongClick()
        {
            InvokeOnMainThread(() => LongClickCount++);
        }
    }
}
