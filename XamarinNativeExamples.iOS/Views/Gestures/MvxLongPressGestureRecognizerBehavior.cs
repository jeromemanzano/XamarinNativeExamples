using MvvmCross.Platforms.Ios.Binding.Views.Gestures;
using UIKit;

namespace XamarinNativeExamples.iOS.Views.Gestures
{
    public class MvxLongPressGestureRecognizerBehavior
    : MvxGestureRecognizerBehavior<UILongPressGestureRecognizer>
    {
        public MvxLongPressGestureRecognizerBehavior(UIView target)
        {
            var lp = new UILongPressGestureRecognizer(HandleGesture);

            AddGestureRecognizer(target, lp);
        }

        protected override void HandleGesture(UILongPressGestureRecognizer gesture)
        {
            if (gesture.State == UIGestureRecognizerState.Began)
            {
                FireCommand();
            }
        }
    }
}