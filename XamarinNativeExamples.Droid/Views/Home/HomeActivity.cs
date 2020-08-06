using Android.App;
using Android.OS;
using XamarinNativeExamples.Core.ViewModels.Home;
using XamarinNativeExamples.Droid.Views.Base;

namespace XamarinNativeExamples.Droid.Views.Home
{
    [Activity(Label = "@string/home")]
    public class HomeActivity : BaseActivity<HomeViewModel>
    {
        protected override int LayoutResource => Resource.Layout.activity_home;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
    }
}