using CoreGraphics;
using MvvmCross;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Platforms.Ios.Views;
using UIKit;
using XamarinNativeExamples.Core.ViewModels.Base;
using XamarinNativeExamples.iOS.Utils;

namespace XamarinNativeExamples.iOS.Views.Base
{
    public abstract class BaseViewController<TViewModel> : MvxViewController<TViewModel>
    where TViewModel : class, IPageViewModel
    {
        protected BaseViewController()
        {
        }

        protected BaseViewController(string nibName)
            : base(nibName, null)
        {
        }

        protected virtual ViewControllerTheme Theme { get; }

        protected bool IsKeyboardHandlerEnabled { get; set; } = true;

        protected CustomPresenter Presenter => Mvx.IoCProvider.Resolve<IMvxIosViewPresenter>() as CustomPresenter;

        protected virtual void InitializeControls() 
        {
            Title = ViewModel?.Title;
        }

        protected virtual void BindControls() { }

        protected virtual void SetViewStateForKeyboard(bool visible, CGRect rect) { }

        protected virtual void Cleanup() { }

        protected virtual void HideKeyboard() { View.EndEditing(true); }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeControls();
            BindControls();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.NavigationBar.ApplyTheme(Theme.NavigationTheme);
        }
    }
}