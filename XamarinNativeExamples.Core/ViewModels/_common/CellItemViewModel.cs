using MvvmCross.Commands;
using XamarinNativeExamples.Core.ViewModels.Base;

namespace XamarinNativeExamples.Core.ViewModels
{
    public abstract class CellItemViewModel : BaseItemViewModel
    {
        private IMvxCommand _toggleFoldStateCommand;
        public IMvxCommand ToggleFoldStateCommand
        {
            get => _toggleFoldStateCommand ?? (_toggleFoldStateCommand = new MvxCommand(ToggleFoldState));
        }


        public bool CellOpen { get; private set; }
        public virtual string Description { get; protected set; }
        public virtual string Title { get; protected set; }

        private void ToggleFoldState()
        {
            InvokeOnMainThread(() => CellOpen = !CellOpen);
        }
    }
}
