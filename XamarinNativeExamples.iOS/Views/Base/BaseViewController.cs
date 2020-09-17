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

            SetTheme();
        }

        private void SetTheme() 
        {
            NavigationController.NavigationBar.PrefersLargeTitles = Theme.LargeTitleNavigationBackground != null;

            var regularNavigationAppearance = new UINavigationBarAppearance();
            regularNavigationAppearance.BackgroundColor = Theme.NavigationBackground;
            regularNavigationAppearance.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = Theme.NavigationTextColor };
            NavigationController.NavigationBar.StandardAppearance = regularNavigationAppearance;

            if (Theme.LargeTitleNavigationBackground != null)
            {
                var largeNavigationAppearance = new UINavigationBarAppearance();
                largeNavigationAppearance.BackgroundImageContentMode = UIViewContentMode.ScaleAspectFill;
                largeNavigationAppearance.BackgroundImage = Theme.LargeTitleNavigationBackground;
                largeNavigationAppearance.LargeTitleTextAttributes = new UIStringAttributes() { ForegroundColor = Theme.NavigationTextColor };
                NavigationController.NavigationBar.ScrollEdgeAppearance = largeNavigationAppearance;
            }

            NavigationController.NavigationBar.TintColor = Theme.NavigationTextColor;
        }
    }
}