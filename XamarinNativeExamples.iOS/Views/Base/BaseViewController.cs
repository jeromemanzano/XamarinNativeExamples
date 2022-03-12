using CoreGraphics;
using Foundation;
using MvvmCross;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Platforms.Ios.Views;
using UIKit;
using XamarinNativeExamples.Core.ViewModels.Base;
using XamarinNativeExamples.iOS.Utils;

namespace XamarinNativeExamples.iOS.Views.Base
{
    public abstract class BaseViewController<TViewModel> : MvxViewController<TViewModel>
    where TViewModel : class, IPageViewModel
    {
        private UITapGestureRecognizer _tapRecognizer;
        private NSObject _keyboardObserverWillShow;
        private NSObject _keyboardObserverWillHide;

        protected BaseViewController()
        {
        }

        protected BaseViewController(string nibName)
            : base(nibName, null)
        {
        }

        protected virtual ViewControllerTheme Theme { get; }

        protected virtual UIScrollView MainScrollView { get; set; }

        protected bool IsKeyboardHandlerEnabled { get; set; } = true;

        protected CustomPresenter Presenter => Mvx.IoCProvider.Resolve<IMvxIosViewPresenter>() as CustomPresenter;

        protected virtual void InitializeControls() 
        {
            Title = ViewModel?.Title;
        }

        protected virtual void BindControls() { }

        protected virtual void SetViewStateForKeyboard(bool visible, CGRect rect) 
        {
            if (MainScrollView != null)
            {
                var bottom = visible ? rect.Height : 0;
                MainScrollView.ContentInset = new UIEdgeInsets(0, 0, bottom, 0);
                MainScrollView.ScrollIndicatorInsets = new UIEdgeInsets(0, 0, bottom, 0);
            }
        }

        protected virtual void Cleanup() { }

        protected virtual void HideKeyboard() { View.EndEditing(true); }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeControls();
            BindControls();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.NavigationBar.ApplyTheme(Theme.NavigationTheme);

            if (IsKeyboardHandlerEnabled)
            {
                if (_tapRecognizer == null)
                {
                    _tapRecognizer = new UITapGestureRecognizer(HideKeyboard);
                }
                RegisterForKeyboardNotifications();
            }
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            if (IsKeyboardHandlerEnabled)
            {
                UnregisterKeyboardNotifications();
            }
        }

        private void RegisterForKeyboardNotifications()
        {
            _keyboardObserverWillShow = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, KeyboardWillShowNotification);
            _keyboardObserverWillHide = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, KeyboardWillHideNotification);
        }

        private void UnregisterKeyboardNotifications()
        {
            if (_keyboardObserverWillShow != null)
            {
                NSNotificationCenter.DefaultCenter.RemoveObserver(_keyboardObserverWillShow);
            }
            if (_keyboardObserverWillHide != null)
            {
                NSNotificationCenter.DefaultCenter.RemoveObserver(_keyboardObserverWillHide);
            }

            _keyboardObserverWillShow = null;
            _keyboardObserverWillHide = null;
        }

        private void KeyboardWillShowNotification(NSNotification notification)
        {
            View?.AddGestureRecognizer(_tapRecognizer);

            var notificationFrameValue = notification.UserInfo
                .ValueForKey(UIKeyboard.FrameEndUserInfoKey) as NSValue;
            var keyboardRect = notificationFrameValue.CGRectValue;

            SetViewStateForKeyboard(true, keyboardRect);
        }

        private void KeyboardWillHideNotification(NSNotification notification)
        {
            View.RemoveGestureRecognizer(_tapRecognizer);

            var notificationFrameValue = notification.UserInfo
                .ValueForKey(UIKeyboard.FrameEndUserInfoKey) as NSValue;
            var keyboardRect = notificationFrameValue.CGRectValue;

            SetViewStateForKeyboard(false, keyboardRect);
        }
    }
}