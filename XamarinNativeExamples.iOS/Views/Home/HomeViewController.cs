using UIKit;
using XamarinNativeExamples.Core.ViewModels.Home;
using XamarinNativeExamples.iOS.Utils;
using XamarinNativeExamples.iOS.Views.Base;

namespace XamarinNativeExamples.iOS.Views.Home
{
    public partial class HomeViewController : BaseViewController<HomeViewModel>
    {
        protected override Theme Theme => Themes.Home;

        public HomeViewController() : base("HomeViewController")
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}

