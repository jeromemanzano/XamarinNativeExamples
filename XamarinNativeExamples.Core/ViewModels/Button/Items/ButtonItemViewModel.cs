using MvvmCross.Commands;
using XamarinNativeExamples.Core.ViewModels.Base;

namespace XamarinNativeExamples.Core.ViewModels.Button.Items
{
    public abstract class ButtonItemViewModel : BaseItemViewModel
    {
        private IMvxCommand _toggleFoldStateCommand;
        public IMvxCommand ToggleFoldStateCommand
        {
            get => _toggleFoldStateCommand ?? (_toggleFoldStateCommand = new MvxCommand(ToggleFoldState));
        }

        private bool _cellOpen;
        public bool CellOpen
        {
            get => _cellOpen;
            private set => SetProperty(ref _cellOpen, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            protected set => SetProperty(ref _title, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            protected set => SetProperty(ref _description, value);
        }

        private string _buttonText;
        public string ButtonText
        {
            get => _buttonText;
            protected set => SetProperty(ref _buttonText, value);
        }

        private void ToggleFoldState() 
        {
            InvokeOnMainThread(() => CellOpen = !CellOpen);
        }
    }
}
