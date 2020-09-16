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

namespace XamarinNativeExamples.iOS.Views.Home
{
    [Register ("HomeViewController")]
    partial class HomeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ButtonLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserInterfaceLabel { get; set; }

        [Action ("ButtonButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ButtonButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ButtonButton != null) {
                ButtonButton.Dispose ();
                ButtonButton = null;
            }

            if (ButtonLabel != null) {
                ButtonLabel.Dispose ();
                ButtonLabel = null;
            }

            if (UserInterfaceLabel != null) {
                UserInterfaceLabel.Dispose ();
                UserInterfaceLabel = null;
            }
        }
    }
}