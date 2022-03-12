using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;

namespace XamarinNativeExamples.iOS.Views.Base
{
    public abstract class BaseItemViewController<TViewModel> : MvxViewController<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
        protected BaseItemViewController()
        {
        }

        protected BaseItemViewController(string nibName)
            : base(nibName, null)
        {
        }

        protected virtual void InitializeControls() { }

        protected virtual void BindControls() { }

        protected virtual void Cleanup() { }

        protected virtual void ApplyTheme() { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeControls();
            ApplyTheme();
            BindControls();
        }
    }
}