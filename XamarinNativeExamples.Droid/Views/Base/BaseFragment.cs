using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views.Fragments;
using MvvmCross.ViewModels;

namespace XamarinNativeExamples.Droid.Views.Base
{
    public abstract class BaseFragment<TViewModel>
    : MvxFragment<TViewModel> where TViewModel : class, IMvxViewModel
    { 
        protected abstract int LayoutResource { get; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(LayoutResource, null);
        }
    }
}