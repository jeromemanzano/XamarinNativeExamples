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

            ButtonButton.ImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
            TextButton.ImageView.ContentMode = UIViewContentMode.ScaleAspectFill;

            HttpButton.ImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
            WebSocketButton.ImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
        }

        protected override void BindControls()
        {
            base.BindControls();

            var set = this.CreateBindingSet<HomeViewController, HomeViewModel>();
            set.Bind(ButtonLabel).To(vm => vm.ButtonTitle);
            set.Bind(ButtonButton).To(vm => vm.OpenButtonCommand);

            set.Bind(UserInterfaceLabel).To(vm => vm.UserInterfaceHeader);
            set.Bind(CommunicationLabel).To(vm => vm.ConnectivityHeader);

            set.Bind(TextLabel).To(vm => vm.TextTitle);
            set.Bind(UserInterfaceLabel).To(vm => vm.UserInterfaceHeader);
            set.Bind(TextButton).To(vm => vm.OpenTextCommand);

            set.Bind(HttpButton).To(vm => vm.OpenRestCommand);

            set.Bind(WebSocketButton).To(vm => vm.OpenWebSocketCommand);

            set.Apply();
        }
    }
}

