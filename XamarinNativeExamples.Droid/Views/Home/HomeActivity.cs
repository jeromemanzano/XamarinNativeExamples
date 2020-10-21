using Android.App;
using Android.OS;
using XamarinNativeExamples.Core.ViewModels.Home;
using XamarinNativeExamples.Droid.Views.Base;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Android.Content.PM;

namespace XamarinNativeExamples.Droid.Views.Home
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class HomeActivity : BaseActivity<HomeViewModel>
    {
        protected override int LayoutResource => Resource.Layout.activity_home;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AppCenter.Start("12acefae-2c7d-4c20-a6b9-c1f08348097f",
                   typeof(Analytics), typeof(Crashes));
        }
    }
}