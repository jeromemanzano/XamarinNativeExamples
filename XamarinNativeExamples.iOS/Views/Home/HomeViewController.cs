using System;

using UIKit;
using XamarinNativeExamples.Core.ViewModels.Home;
using XamarinNativeExamples.iOS.Views.Base;

namespace XamarinNativeExamples.iOS.Views.Home
{
    public partial class HomeViewController : BaseViewController<HomeViewModel>
    {
        public HomeViewController() : base("HomeViewController")
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

