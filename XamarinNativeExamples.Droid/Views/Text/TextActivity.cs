using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using XamarinNativeExamples.Core.ViewModels.Text;
using XamarinNativeExamples.Droid.Views.Base;

namespace XamarinNativeExamples.Droid.Views.Text
{
    [Activity(Label = "@string/text", Theme = "@style/TextPageTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class TextActivity : BaseActivity<TextViewModel>
    {
        protected override int LayoutResource => Resource.Layout.activity_text;

        protected override int? ToolbarTitle => Resource.String.text;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
    }
}