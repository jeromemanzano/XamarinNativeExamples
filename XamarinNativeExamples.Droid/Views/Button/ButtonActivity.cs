using Android.App;
using Android.OS;
using XamarinNativeExamples.Core.ViewModels.Button;
using XamarinNativeExamples.Droid.Views.Base;

namespace XamarinNativeExamples.Droid.Views.Button
{
    [Activity(Label = "@string/button", Theme = "@style/ButtonPageTheme")]
    public class ButtonActivity : BaseActivity<ButtonViewModel>
    {
        protected override int LayoutResource => Resource.Layout.activity_button;

        protected override int? ToolbarTitle => Resource.String.button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
    }
}