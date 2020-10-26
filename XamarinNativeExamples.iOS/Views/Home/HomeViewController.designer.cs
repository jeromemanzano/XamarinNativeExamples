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
        UIKit.UILabel CommunicationLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView CommunicationScroll { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton HttpButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton TextButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TextLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserInterfaceLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton WebSocketButton { get; set; }

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

            if (CommunicationLabel != null) {
                CommunicationLabel.Dispose ();
                CommunicationLabel = null;
            }

            if (CommunicationScroll != null) {
                CommunicationScroll.Dispose ();
                CommunicationScroll = null;
            }

            if (HttpButton != null) {
                HttpButton.Dispose ();
                HttpButton = null;
            }

            if (TextButton != null) {
                TextButton.Dispose ();
                TextButton = null;
            }

            if (TextLabel != null) {
                TextLabel.Dispose ();
                TextLabel = null;
            }

            if (UserInterfaceLabel != null) {
                UserInterfaceLabel.Dispose ();
                UserInterfaceLabel = null;
            }

            if (WebSocketButton != null) {
                WebSocketButton.Dispose ();
                WebSocketButton = null;
            }
        }
    }
}