using System;

using UIKit;
using XamarinNativeExamples.Core.ViewModels.Button;
using XamarinNativeExamples.iOS.Utils;
using XamarinNativeExamples.iOS.Views.Base;

namespace XamarinNativeExamples.iOS.Views.Button
{
    public partial class ButtonViewController : BaseViewController<ButtonViewModel>
    {
        protected override Theme Theme => Themes.Button;

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

        //public override void ViewWillAppear(bool animated)
        //{
        //    base.ViewWillAppear(animated);
        //    UpdateNavigationBar();
        //}

        //private void UpdateNavigationBar() 
        //{
        //    var largeAppearance = new UINavigationBarAppearance();
        //    //largeAppearance.ConfigureWithOpaqueBackground();
        //    var image = UIImage.FromBundle("ButtonPanel");
        //    largeAppearance.ConfigureWithTransparentBackground();
        //    largeAppearance.BackgroundEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.ExtraDark);
        //    largeAppearance.BackgroundImageContentMode = UIViewContentMode.ScaleAspectFill;
        //    largeAppearance.BackgroundImage = UIImage.FromBundle("ButtonPanel");
        //    largeAppearance.LargeTitleTextAttributes = new UIStringAttributes() { ForegroundColor = Theme.NavigationTextColor };

        //    var appearance = new UINavigationBarAppearance();
        //    appearance.ConfigureWithOpaqueBackground();
        //    appearance.BackgroundColor = UIColor.FromName("MustardYellow");
        //    appearance.BackgroundEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.ExtraDark);
        //    appearance.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = Theme.NavigationTextColor };

        //    NavigationController.NavigationBar.StandardAppearance = appearance;
        //    NavigationController.NavigationBar.ScrollEdgeAppearance = largeAppearance;
        //    NavigationController.NavigationItem.HidesBackButton = true;
        //    //NavigationController.NavigationBar.TintColor = UIColor.Blue;
        //    NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = UIColor.Orange };
        //    NavigationController.NavigationItem.BackBarButtonItem = new UIBarButtonItem(title: " ", style: UIBarButtonItemStyle.Plain, null);
        //}
    }
}

