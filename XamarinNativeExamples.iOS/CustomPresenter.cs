using MvvmCross.Platforms.Ios.Presenters;
using UIKit;

namespace XamarinNativeExamples.iOS
{
    public class CustomPresenter : MvxIosViewPresenter
    {
        public CustomPresenter(IUIApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
        }
    }
}