using Android.OS;
using Android.Views;
using AndroidX.AppCompat.Widget;
using MvvmCross;
using MvvmCross.Platforms.Android.Presenters;
using MvvmCross.Platforms.Android.Views;
using Plugin.CurrentActivity;
using Xamarin.Essentials;
using XamarinNativeExamples.Core.ViewModels.Base;

namespace XamarinNativeExamples.Droid.Views.Base
{
    public abstract class BaseActivity<TViewModel>
        : MvxActivity<TViewModel> where TViewModel : class, IPageViewModel
    {
        protected abstract int LayoutResource { get; }

        protected virtual int? ToolbarTitle { get; }

        protected CustomPresenter Presenter => Mvx.IoCProvider.Resolve<IMvxAndroidViewPresenter>() as CustomPresenter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Platform.Init(this, bundle);
            CrossCurrentActivity.Current.Init(this, bundle);

            SetContentView(LayoutResource);
            SetupTitle();
        }

        protected virtual void SetupTitle()
        {
            if (ViewModel.Title == null)
            {
                return;
            }

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.Title = ViewModel.Title;
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home)
            {
                ViewModel.BackCommand.Execute();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            ViewModel?.BackCommand?.Execute();
        }
    }
}