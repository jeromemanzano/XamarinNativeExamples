using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace XamarinNativeExamples.Core.ViewModels.Base
{
    public abstract class BasePageViewModel : MvxViewModel, IPageViewModel
    {
        protected readonly IMvxNavigationService Navigation;

        protected BasePageViewModel()
        {
            Navigation = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
        }

        private IMvxCommand _backCommand;
        public IMvxCommand BackCommand
        {
            get => _backCommand ?? (_backCommand = new MvxAsyncCommand(BackAsync));
        }

        public virtual string Title { get; protected set; }

        protected virtual Task BackAsync()
        {
            return Navigation.Close(this);
        }
    }
}
