using MvvmCross.Commands;
using XamarinNativeExamples.Core.ViewModels.Base;

namespace XamarinNativeExamples.Core.ViewModels
{
    public abstract class CellItemViewModel : BaseItemViewModel
    {
        public bool CellOpen { get; private set; }
        public virtual string Description { get; }
        public virtual string Title { get; }
        
        private IMvxCommand _toggleFoldStateCommand;

        public IMvxCommand ToggleFoldStateCommand => _toggleFoldStateCommand ??= new MvxCommand(ToggleFoldState);

        private void ToggleFoldState()
        {
            CellOpen = !CellOpen;
        }
    }
}
