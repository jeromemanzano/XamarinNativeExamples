using MvvmCross.Binding.BindingContext;
using UIKit;
using XamarinNativeExamples.Core.ViewModels.Home;
using XamarinNativeExamples.iOS.Utils;
using XamarinNativeExamples.iOS.Views.Base;

namespace XamarinNativeExamples.iOS.Views.Home
{
    public partial class HomeViewController : BaseViewController<HomeViewModel>
    {
        protected override ViewControllerTheme Theme => Themes.Home;

        public HomeViewController() : base("HomeViewController")
        {
        }
        protected override void InitializeControls()
        {
            base.InitializeControls();

            EdgesForExtendedLayout = UIRectEdge.None;

            ButtonButton.Bounds = new CoreGraphics.CGRect(0, 0, 100, 160);
            ButtonButton.ImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
        }

        protected override void BindControls()
        {
            base.BindControls();

            var set = this.CreateBindingSet<HomeViewController, HomeViewModel>();
            set.Bind(ButtonLabel).To(vm => vm.ButtonTitle);
            set.Bind(UserInterfaceLabel).To(vm => vm.UserInterfaceHeader);
            set.Bind(ButtonButton).To(vm => vm.OpenButtonCommand);

            set.Apply();
        }
    }
}

