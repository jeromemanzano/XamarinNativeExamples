using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.ViewModels;
using XamarinNativeExamples.Core.ViewModels.Text;
using XamarinNativeExamples.Core.ViewModels.Text.Items;
using XamarinNativeExamples.Droid.Views.Base;

namespace XamarinNativeExamples.Droid.Views.Text
{
    [Activity(Theme = "@style/TextPageTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class TextActivity : BaseActivity<TextViewModel>
    {
        protected override int LayoutResource => Resource.Layout.activity_text;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Presenter.Show(new MvxViewModelRequest(typeof(TextTextItemViewModel)));
            Presenter.Show(new MvxViewModelRequest(typeof(TextFilterItemViewModel)));
        }
    }
}