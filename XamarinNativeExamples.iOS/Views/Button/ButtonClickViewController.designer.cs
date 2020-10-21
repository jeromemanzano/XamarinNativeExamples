// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamarinNativeExamples.iOS.Views.Button
{
    [Register ("ButtonClickViewController")]
    partial class ButtonClickViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ClickButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ClickCountLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ClickLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ContainerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DescriptionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LongClickCountLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LongClickLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ClickButton != null) {
                ClickButton.Dispose ();
                ClickButton = null;
            }

            if (ClickCountLabel != null) {
                ClickCountLabel.Dispose ();
                ClickCountLabel = null;
            }

            if (ClickLabel != null) {
                ClickLabel.Dispose ();
                ClickLabel = null;
            }

            if (ContainerView != null) {
                ContainerView.Dispose ();
                ContainerView = null;
            }

            if (DescriptionLabel != null) {
                DescriptionLabel.Dispose ();
                DescriptionLabel = null;
            }

            if (LongClickCountLabel != null) {
                LongClickCountLabel.Dispose ();
                LongClickCountLabel = null;
            }

            if (LongClickLabel != null) {
                LongClickLabel.Dispose ();
                LongClickLabel = null;
            }
        }
    }
}