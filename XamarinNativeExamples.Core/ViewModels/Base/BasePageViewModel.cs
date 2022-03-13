using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using XamarinNativeExamples.Core.Managers.Interactions;

namespace XamarinNativeExamples.Core.ViewModels.Base
{
    public abstract class BasePageViewModel : MvxNavigationViewModel, IPageViewModel
    {
        protected IInteractionManager Interactions { get; }

        protected BasePageViewModel(ILoggerFactory loggerFactory, 
            IMvxNavigationService navigationService,
            IInteractionManager interactionManager)
            :base(loggerFactory, navigationService)
        {
            Interactions = interactionManager;
        }

        private IMvxAsyncCommand _backCommand;
        public IMvxAsyncCommand BackCommand => _backCommand ??= new MvxAsyncCommand(BackAsync);

        public virtual string Title { get; }

        protected virtual Task BackAsync()
        {
            return NavigationService.Close(this);
        }
    }

    public abstract class BaseResultPageViewModel<TResult> : 
        BasePageViewModel, 
        IMvxViewModelResult<TResult>
        where TResult : notnull
    {
        protected BaseResultPageViewModel(ILoggerFactory loggerFactory, 
            IMvxNavigationService navigationService,
            IInteractionManager interactionManager)
            :base(loggerFactory, navigationService, interactionManager)
        {
        }
        
        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (viewFinishing && CloseCompletionSource != null && !CloseCompletionSource.Task.IsCompleted && !CloseCompletionSource.Task.IsFaulted)
                CloseCompletionSource.TrySetCanceled();

            base.ViewDestroy(viewFinishing);
        }
    }

    public class NavigationResult
    {
        public bool Success { get; }

        public NavigationResult(bool success)
        {
            Success = success;
        }
    }
}
