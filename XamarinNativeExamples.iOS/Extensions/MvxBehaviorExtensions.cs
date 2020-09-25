using XamarinNativeExamples.iOS.Views.Gestures;

namespace UIKit
{
    public static class MvxBehaviorExtensions
    {
        public static MvxLongPressGestureRecognizerBehavior LongPress(this UIView view)
        {
            return new MvxLongPressGestureRecognizerBehavior(view);
        }
    }
}