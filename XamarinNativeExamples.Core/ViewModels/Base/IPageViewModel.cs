
using System.ComponentModel;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace XamarinNativeExamples.Core.ViewModels.Base
{
    public interface IPageViewModel : IMvxViewModel, INotifyPropertyChanged
    {
        IMvxCommand BackCommand { get; }

        string Title { get; }
    }
}
