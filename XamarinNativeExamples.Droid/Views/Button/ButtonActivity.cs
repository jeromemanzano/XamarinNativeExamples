using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.ViewModels;
using XamarinNativeExamples.Core.ViewModels.Button;
using XamarinNativeExamples.Core.ViewModels.Button.Items;
using XamarinNativeExamples.Droid.Views.Base;

namespace XamarinNativeExamples.Droid.Views.Button
{
    [Activity(Label = "@string/button", Theme = "@style/ButtonPageTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ButtonActivity : BaseActivity<ButtonViewModel>
    {
        protected override int LayoutResource => Resource.Layout.activity_button;

        protected override int? ToolbarTitle => Resource.String.button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Presenter.Show(new MvxViewModelRequest(typeof(ButtonClickItemViewModel)));
            Presenter.Show(new MvxViewModelRequest(typeof(ButtonEnableItemViewModel)));
        }
    }
}