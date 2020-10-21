using System;
using System.Threading.Tasks;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.ViewModels;

namespace XamarinNativeExamples.Droid
{
    public class CustomPresenter : MvxAndroidViewPresenter
    {
        public CustomPresenter() : base(null)
        {
        }
    }
}