using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using XamarinNativeExamples.Core.ViewModels.Http;
using XamarinNativeExamples.Droid.Views.Base;

namespace XamarinNativeExamples.Droid.Views.Http
{
    [Activity(Theme = "@style/HttpPageTheme", ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustResize)]
    public class HttpActivity : BaseActivity<HttpViewModel>
    {
        protected override int LayoutResource => Resource.Layout.activity_http;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
    }
}