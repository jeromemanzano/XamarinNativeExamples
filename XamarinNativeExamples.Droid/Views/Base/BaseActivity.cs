using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
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

        protected virtual int? ToolbarTitle { get; }

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
            if (!ToolbarTitle.HasValue)
            {
                return;
            }

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                toolbar.SetTitle(ToolbarTitle.Value);
                SetSupportActionBar(toolbar);
                SupportActionBar.Title = Title;
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