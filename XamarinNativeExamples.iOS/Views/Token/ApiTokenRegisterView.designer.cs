// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace XamarinNativeExamples.iOS
{
    [Register ("ApiTokenRegisterView")]
    partial class ApiTokenRegisterView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel RegisterLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (RegisterLabel != null) {
                RegisterLabel.Dispose ();
                RegisterLabel = null;
            }
        }
    }
}