using CoreGraphics;
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

        protected virtual Theme Theme { get; }

        protected bool IsKeyboardHandlerEnabled { get; set; } = true;

        protected virtual void InitializeControls() { }

        protected virtual void BindControls() { }

        protected virtual void SetViewStateForKeyboard(bool visible, CGRect rect) { }

        protected virtual void Cleanup() { }

        protected virtual void HideKeyboard() { View.EndEditing(true); }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel?.Title;

            SetTheme();
            InitializeControls();
            BindControls();
        }

        private void SetTheme() 
        {
            NavigationController.NavigationBar.BarTintColor = Theme.BarTintColor;
            NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = Theme.TitleForegroundColor };
        }
    }
}