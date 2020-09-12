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
        public IMvxCommand LongClickCommand
        {
            get => _longClickCommand ?? (_longClickCommand = new MvxCommand(ProcessLongClick));
        }

        private int _clickCount;
        public int ClickCount
        {
            get => _clickCount;
            private set => SetProperty(ref _clickCount, value);
        }

        private int _longClickCount;
        public int LongClickCount
        {
            get => _longClickCount;
            private set => SetProperty(ref _longClickCount, value);
        }

        private string _buttonText;
        public string ButtonText
        {
            get => _buttonText;
            private set => SetProperty(ref _buttonText, value);
        }

        public override Task Initialize()
        {
            InvokeOnMainThread(() =>
            {
                Title = Resources.ButtonClickHeader;
                ButtonText = Resources.TryMe;
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
