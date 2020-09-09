using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;

namespace XamarinNativeExamples.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.Splash", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : MvxSplashScreenActivity
    {
    }
}