using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using Plugin.CurrentActivity;
using Xamarin.Essentials;
using XamarinNativeExamples.Core.ViewModels.Base;

namespace XamarinNativeExamples.Droid.Views.Base
{
    public abstract class BaseActivity<TViewModel>
        : MvxAppCompatActivity<TViewModel> where TViewModel : class, IPageViewModel
    {
        protected abstract int LayoutResource { get; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Platform.Init(this, bundle);
            CrossCurrentActivity.Current.Init(this, bundle);

            SetContentView(LayoutResource);
        }
    }
}