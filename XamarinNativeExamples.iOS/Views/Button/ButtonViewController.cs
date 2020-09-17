using System;

using UIKit;
using XamarinNativeExamples.Core.ViewModels.Button;
using XamarinNativeExamples.iOS.Utils;
using XamarinNativeExamples.iOS.Views.Base;

namespace XamarinNativeExamples.iOS.Views.Button
{
    public partial class ButtonViewController : BaseViewController<ButtonViewModel>
    {
        protected override Theme Theme => Themes.Home;

        public ButtonViewController() : base("ButtonViewController")
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

        protected override void InitializeControls()
        {
            base.InitializeControls();

            EdgesForExtendedLayout = UIRectEdge.None;
        }
    }
}

