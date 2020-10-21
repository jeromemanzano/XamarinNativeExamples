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
            #if ENABLE_TEST_CLOUD
              Xamarin.Calabash.Start();
            #endif

            var result = base.FinishedLaunching(application, launchOptions);

            // here is where your custom code should be placed

            return result;
        }
    }
}