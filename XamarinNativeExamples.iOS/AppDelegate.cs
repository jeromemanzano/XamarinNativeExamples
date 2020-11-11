using Foundation;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
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

            AppCenter.Start("4c261955-6d13-4cd4-a289-6b6c33f56223",
                   typeof(Analytics), typeof(Crashes));

            return result;
        }
    }
}