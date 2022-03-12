using MvvmCross.Commands;
using XamarinNativeExamples.Core.Properties;

namespace XamarinNativeExamples.Core.ViewModels.Button.Items
{
    public class ButtonEnableItemViewModel : CellItemViewModel
    {
        public override string Title => Resources.ButtonEnableHeader;
        public string ButtonText => Resources.TryMe;
        public string ClickLabel => Resources.ClickCountLabel;
        public int ClickCount { get; private set; }
        public bool ButtonEnabled { get; private set; } = true;

        private IMvxCommand _clickCommand;
        public IMvxCommand ClickCommand => _clickCommand ??= new MvxCommand(ProcessClick);

        private void ProcessClick()
        {
            ClickCount++;
        }
    }
}
