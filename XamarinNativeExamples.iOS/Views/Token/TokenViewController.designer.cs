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

namespace XamarinNativeExamples.iOS.Views.Token
{
    [Register ("TokenViewController")]
    partial class TokenViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPageControl TokenPageControl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView TokenScrollView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (TokenPageControl != null) {
                TokenPageControl.Dispose ();
                TokenPageControl = null;
            }

            if (TokenScrollView != null) {
                TokenScrollView.Dispose ();
                TokenScrollView = null;
            }
        }
    }
}