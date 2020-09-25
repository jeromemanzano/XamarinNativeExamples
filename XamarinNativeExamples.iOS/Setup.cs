using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using UIKit;
using XamarinNativeExamples.Core;

namespace XamarinNativeExamples.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override IMvxIosViewPresenter CreateViewPresenter()
        {
            return new CustomPresenter(ApplicationDelegate as UIApplicationDelegate, Window);
        }
    }
}