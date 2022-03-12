using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using UIKit;
using XamarinNativeExamples.Core.ViewModels.Button;
using XamarinNativeExamples.Core.ViewModels.Button.Items;
using XamarinNativeExamples.iOS.Utils;
using XamarinNativeExamples.iOS.Views.Base;

namespace XamarinNativeExamples.iOS.Views.Button
{
    public partial class ButtonViewController : BaseViewController<ButtonViewModel>
    {
        protected override ViewControllerTheme Theme => Themes.Button;

        private ButtonClickViewController _buttonClickViewController;
        private ButtonEnableViewController _buttonEnableViewController;

        private UIView _buttonClickView;
        private UIView _buttonEnableView;

        public ButtonViewController() : base("ButtonViewController")
        {
            var buttonClickViewModelRequest = new MvxViewModelRequest(typeof(ButtonClickItemViewModel));
            _buttonClickViewController = Presenter.CreateViewControllerFor<ButtonClickItemViewModel>(buttonClickViewModelRequest)
                as ButtonClickViewController;

            _buttonClickView = _buttonClickViewController?.View;

            var buttonEnableViewModelRequest = new MvxViewModelRequest(typeof(ButtonEnableItemViewModel));
            _buttonEnableViewController = Presenter.CreateViewControllerFor<ButtonEnableItemViewModel>(buttonEnableViewModelRequest)
                as ButtonEnableViewController;

            _buttonEnableView = _buttonEnableViewController?.View;
        }

        protected override void InitializeControls()
        {
            base.InitializeControls();

            EdgesForExtendedLayout = UIRectEdge.None;

            var scrollView = new UIScrollView();
            scrollView.TranslatesAutoresizingMaskIntoConstraints = false;

            var containerView = new UIView();
            containerView.TranslatesAutoresizingMaskIntoConstraints = false;

            AddChildViewController(_buttonClickViewController);
            AddChildViewController(_buttonEnableViewController);

            View.AddSubview(scrollView);
            scrollView.AddSubview(containerView);

            containerView.AddSubview(_buttonClickView);
            containerView.AddSubview(_buttonEnableView);

            _buttonClickView.TranslatesAutoresizingMaskIntoConstraints = false;
            _buttonEnableView.TranslatesAutoresizingMaskIntoConstraints = false;

            _buttonClickViewController.DidMoveToParentViewController(this);
            _buttonEnableViewController.DidMoveToParentViewController(this);

            scrollView.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor).Active = true;
            scrollView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            scrollView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
            scrollView.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;

            containerView.TopAnchor.ConstraintEqualTo(scrollView.TopAnchor).Active = true;
            containerView.LeadingAnchor.ConstraintEqualTo(scrollView.LeadingAnchor).Active = true;
            containerView.TrailingAnchor.ConstraintEqualTo(scrollView.TrailingAnchor).Active = true;
            containerView.BottomAnchor.ConstraintEqualTo(scrollView.BottomAnchor).Active = true;
            containerView.WidthAnchor.ConstraintEqualTo(scrollView.WidthAnchor).Active = true;

            _buttonClickView.TopAnchor.ConstraintEqualTo(containerView.TopAnchor, 50f).Active = true;
            _buttonClickView.LeadingAnchor.ConstraintEqualTo(containerView.LeadingAnchor, 20f).Active = true;
            _buttonClickView.TrailingAnchor.ConstraintEqualTo(containerView.TrailingAnchor, -20f).Active = true;

            _buttonEnableView.TopAnchor.ConstraintEqualTo(_buttonClickView.BottomAnchor, 20f).Active = true;
            _buttonEnableView.LeadingAnchor.ConstraintEqualTo(containerView.LeadingAnchor, 20f).Active = true;
            _buttonEnableView.TrailingAnchor.ConstraintEqualTo(containerView.TrailingAnchor, -20f).Active = true;
            _buttonEnableView.BottomAnchor.ConstraintEqualTo(scrollView.BottomAnchor, -20f).Active = true;
        }
    }
}

