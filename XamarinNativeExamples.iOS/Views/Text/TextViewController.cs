using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using UIKit;
using XamarinNativeExamples.Core.ViewModels.Text;
using XamarinNativeExamples.Core.ViewModels.Text.Items;
using XamarinNativeExamples.iOS.Utils;
using XamarinNativeExamples.iOS.Views.Base;

namespace XamarinNativeExamples.iOS.Views.Text
{
    public partial class TextViewController : BaseViewController<TextViewModel>
    {
        protected override ViewControllerTheme Theme => Themes.Text;

        private TextTextViewController _textTextViewController;
        private TextFilterViewController _textFilterViewController;

        private UIView _textTextView;
        private UIView textFilterView;

        public TextViewController() : base("TextViewController")
        {
            var textTextViewModelRequest = new MvxViewModelRequest(typeof(TextTextItemViewModel));
            _textTextViewController = Presenter.CreateViewControllerFor<TextTextItemViewModel>(textTextViewModelRequest)
                as TextTextViewController;

            _textTextView = _textTextViewController.View;

            var textFilterItemViewModel = new MvxViewModelRequest(typeof(TextFilterItemViewModel));
            _textFilterViewController = Presenter.CreateViewControllerFor<TextFilterItemViewModel>(textFilterItemViewModel)
                as TextFilterViewController;

            textFilterView = _textFilterViewController.View;
        }

        protected override void InitializeControls()
        {
            base.InitializeControls();

            EdgesForExtendedLayout = UIRectEdge.None;

            var scrollView = new UIScrollView();
            scrollView.TranslatesAutoresizingMaskIntoConstraints = false;

            var containerView = new UIView();
            containerView.TranslatesAutoresizingMaskIntoConstraints = false;

            AddChildViewController(_textTextViewController);
            AddChildViewController(_textFilterViewController);

            View.AddSubview(scrollView);
            scrollView.AddSubview(containerView);

            containerView.AddSubview(_textTextView);
            containerView.AddSubview(textFilterView);

            _textTextView.TranslatesAutoresizingMaskIntoConstraints = false;
            textFilterView.TranslatesAutoresizingMaskIntoConstraints = false;

            _textTextViewController.DidMoveToParentViewController(this);
            _textFilterViewController.DidMoveToParentViewController(this);

            scrollView.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor).Active = true;
            scrollView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            scrollView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
            scrollView.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;

            containerView.TopAnchor.ConstraintEqualTo(scrollView.TopAnchor).Active = true;
            containerView.LeadingAnchor.ConstraintEqualTo(scrollView.LeadingAnchor).Active = true;
            containerView.TrailingAnchor.ConstraintEqualTo(scrollView.TrailingAnchor).Active = true;
            containerView.BottomAnchor.ConstraintEqualTo(scrollView.BottomAnchor).Active = true;
            containerView.WidthAnchor.ConstraintEqualTo(scrollView.WidthAnchor).Active = true;

            _textTextView.TopAnchor.ConstraintEqualTo(containerView.TopAnchor, 50f).Active = true;
            _textTextView.LeadingAnchor.ConstraintEqualTo(containerView.LeadingAnchor, 20f).Active = true;
            _textTextView.TrailingAnchor.ConstraintEqualTo(containerView.TrailingAnchor, -20f).Active = true;

            textFilterView.TopAnchor.ConstraintEqualTo(_textTextView.BottomAnchor, 20f).Active = true;
            textFilterView.LeadingAnchor.ConstraintEqualTo(containerView.LeadingAnchor, 20f).Active = true;
            textFilterView.TrailingAnchor.ConstraintEqualTo(containerView.TrailingAnchor, -20f).Active = true;
            textFilterView.BottomAnchor.ConstraintEqualTo(scrollView.BottomAnchor, -20f).Active = true;
        }
    }
}

