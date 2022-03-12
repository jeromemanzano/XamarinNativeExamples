using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using XamarinNativeExamples.Core.Managers.Interactions;

namespace XamarinNativeExamples.Core.ViewModels.Base
{
    public abstract class BasePageViewModel : MvxViewModel, IPageViewModel
    {
        protected IMvxIoCProvider IoCProvider { get; } = Mvx.IoCProvider;

        protected IMvxNavigationService Navigation { get; }
        protected IInteractionManager Interactions { get; }

        protected BasePageViewModel()
        {
            Navigation = IoCProvider.Resolve<IMvxNavigationService>();
            Interactions = IoCProvider.Resolve<IInteractionManager>();
        }

        private IMvxCommand _backCommand;
        public IMvxCommand BackCommand => _backCommand ??= new MvxAsyncCommand(BackAsync);

        public virtual string Title { get; }

        protected virtual Task BackAsync()
        {
            return Navigation.Close(this);
        }
    }

    public abstract class BaseResultPageViewModel<TResult> : 
        BasePageViewModel, 
        IMvxViewModelResult<TResult>
        where TResult : notnull
    {
        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (viewFinishing && CloseCompletionSource != null &&
                !CloseCompletionSource.Task.IsCompleted &&
                !CloseCompletionSource.Task.IsFaulted)
            {
                CloseCompletionSource.TrySetCanceled();
            }

            base.ViewDestroy(viewFinishing);
        }
    }
}
