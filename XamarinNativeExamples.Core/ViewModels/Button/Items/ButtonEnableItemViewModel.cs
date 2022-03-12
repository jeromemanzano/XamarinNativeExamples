using System.Threading.Tasks;
using MvvmCross.Commands;
using XamarinNativeExamples.Core.Properties;

namespace XamarinNativeExamples.Core.ViewModels.Button.Items
{
    public class ButtonEnableItemViewModel : CellItemViewModel
    {
        private IMvxCommand _clickCommand;
        public IMvxCommand ClickCommand
        {
            get => _clickCommand ?? (_clickCommand = new MvxCommand(ProcessClick));
        }

        public int ClickCount { get; private set; }
        public bool ButtonEnabled { get; private set; }

        public string ButtonText => Resources.TryMe;

        public string ClickLabel => Resources.ClickCountLabel;

        public override Task Initialize()
        {
            InvokeOnMainThread(() =>
            {
                Title = Resources.ButtonEnableHeader;
                ButtonEnabled = true;
            });

            return base.Initialize();
        }

        private void ProcessClick()
        {
            InvokeOnMainThread(() => ClickCount++);
        }
    }
}
