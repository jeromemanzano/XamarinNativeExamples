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

namespace XamarinNativeExamples.iOS.Views.Text
{
    [Register ("TextFilterViewController")]
    partial class TextFilterViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ContainerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DescriptionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField FilterInputPickerTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField InputTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ContainerView != null) {
                ContainerView.Dispose ();
                ContainerView = null;
            }

            if (DescriptionLabel != null) {
                DescriptionLabel.Dispose ();
                DescriptionLabel = null;
            }

            if (FilterInputPickerTextField != null) {
                FilterInputPickerTextField.Dispose ();
                FilterInputPickerTextField = null;
            }

            if (InputTextField != null) {
                InputTextField.Dispose ();
                InputTextField = null;
            }
        }
    }
}