using CoreGraphics;
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

            MainScrollView = new UIScrollView();
            MainScrollView.TranslatesAutoresizingMaskIntoConstraints = false;

            var containerView = new UIView();
            containerView.TranslatesAutoresizingMaskIntoConstraints = false;

            AddChildViewController(_textTextViewController);
            AddChildViewController(_textFilterViewController);

            View.AddSubview(MainScrollView);
            MainScrollView.AddSubview(containerView);

            containerView.AddSubview(_textTextView);
            containerView.AddSubview(textFilterView);

            _textTextView.TranslatesAutoresizingMaskIntoConstraints = false;
            textFilterView.TranslatesAutoresizingMaskIntoConstraints = false;

            _textTextViewController.DidMoveToParentViewController(this);
            _textFilterViewController.DidMoveToParentViewController(this);

            MainScrollView.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor).Active = true;
            MainScrollView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            MainScrollView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
            MainScrollView.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;

            containerView.TopAnchor.ConstraintEqualTo(MainScrollView.TopAnchor).Active = true;
            containerView.LeadingAnchor.ConstraintEqualTo(MainScrollView.LeadingAnchor).Active = true;
            containerView.TrailingAnchor.ConstraintEqualTo(MainScrollView.TrailingAnchor).Active = true;
            containerView.BottomAnchor.ConstraintEqualTo(MainScrollView.BottomAnchor).Active = true;
            containerView.WidthAnchor.ConstraintEqualTo(MainScrollView.WidthAnchor).Active = true;

            _textTextView.TopAnchor.ConstraintEqualTo(containerView.TopAnchor, 50f).Active = true;
            _textTextView.LeadingAnchor.ConstraintEqualTo(containerView.LeadingAnchor, 20f).Active = true;
            _textTextView.TrailingAnchor.ConstraintEqualTo(containerView.TrailingAnchor, -20f).Active = true;

            textFilterView.TopAnchor.ConstraintEqualTo(_textTextView.BottomAnchor, 20f).Active = true;
            textFilterView.LeadingAnchor.ConstraintEqualTo(containerView.LeadingAnchor, 20f).Active = true;
            textFilterView.TrailingAnchor.ConstraintEqualTo(containerView.TrailingAnchor, -20f).Active = true;
            textFilterView.BottomAnchor.ConstraintEqualTo(MainScrollView.BottomAnchor, -20f).Active = true;
        }

        protected override void SetViewStateForKeyboard(bool visible, CGRect rect)
        {
            base.SetViewStateForKeyboard(visible, rect);

            var bottom = visible ? rect.Height : 0;
            MainScrollView.ContentInset = new UIEdgeInsets(0, 0, bottom, 0);
            MainScrollView.ScrollIndicatorInsets = new UIEdgeInsets(0, 0, bottom, 0);
        }
    }
}

