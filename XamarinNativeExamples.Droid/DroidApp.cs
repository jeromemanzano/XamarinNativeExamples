using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using XamarinNativeExamples.Core;

namespace XamarinNativeExamples.Droid
{
    [Application]
    public class DroidApp : MvxAndroidApplication<Setup, App>, Application.IActivityLifecycleCallbacks
    { 
        public DroidApp(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            RegisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
        }

        public void OnActivityStopped(Activity activity)
        {
        }
    }
}