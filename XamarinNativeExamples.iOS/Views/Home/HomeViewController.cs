﻿using System;

using UIKit;

namespace XamarinNativeExamples.iOS.Views.Home
{
    public partial class HomeViewController : UIViewController
    {
        public HomeViewController() : base("HomeViewController", null)
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

