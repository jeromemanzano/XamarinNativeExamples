using Foundation;
using MvvmCross.Platforms.Ios.Core;
using UIKit;
using XamarinNativeExamples.Core;

namespace XamarinNativeExamples.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
        [Export("window")]
        // class-level declarations
        public override UIWindow Window
        {
            get;
            set;
        }

        [Export("application:didFinishLaunchingWithOptions:")]
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // create a new window instance based on the screen size
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = new UIViewController();

            // make the window visible
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}