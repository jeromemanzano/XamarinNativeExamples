using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using XamarinNativeExamples.Core.ViewModels.WebSocket;
using XamarinNativeExamples.Droid.Views.Base;

namespace XamarinNativeExamples.Droid.Views.WebSocket
{
    [Activity(Theme = "@style/WebSocketPageTheme", ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustResize)]
    public class WebSocketActivity : BaseActivity<WebSocketViewModel>
    {
        protected override int LayoutResource => Resource.Layout.activity_websocket;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
    }
}