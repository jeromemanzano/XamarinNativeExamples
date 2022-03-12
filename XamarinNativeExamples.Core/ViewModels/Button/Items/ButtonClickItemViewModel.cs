using System.Threading.Tasks;
using MvvmCross.Commands;
using XamarinNativeExamples.Core.Properties;

namespace XamarinNativeExamples.Core.ViewModels.Button.Items
{
    public class ButtonClickItemViewModel : CellItemViewModel
    {
        public override string Title => Resources.ButtonClickHeader;
        public string LongClickLabel => Resources.LongClickCountLabel;
        public string ClickLabel => Resources.ClickCountLabel;
        public int ClickCount { get; private set; }
        public int LongClickCount { get; private set; }
        public string ButtonText => Resources.TryMe;

        private IMvxCommand _clickCommand;
        public IMvxCommand ClickCommand => _clickCommand ??= new MvxCommand(ProcessClick);

        private IMvxCommand _longClickCommand;
        public IMvxCommand LongClickCommand => _longClickCommand ??= new MvxCommand(ProcessLongClick);

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
