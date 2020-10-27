using System;
using UIKit;
using XamarinNativeExamples.Core.ViewModels.Token;
using XamarinNativeExamples.iOS.Utils;
using XamarinNativeExamples.iOS.Views.Base;
using MvvmCross.Binding.BindingContext;

namespace XamarinNativeExamples.iOS.Views.Token
{
    public partial class TokenViewController : BaseViewController<TokenViewModel>
    {
        protected override ViewControllerTheme Theme => Themes.Token;

        private TokenStartSubView _startView;
        private TokenRegisterSubView _registerView;
        private TokenCopySubView _copyView;
        private TokenTestSubView _testView;

        public TokenViewController() : base("TokenViewController")
        {
        }

        protected override void InitializeControls()
        {
            base.InitializeControls();

            TokenScrollView.ContentInsetAdjustmentBehavior = UIScrollViewContentInsetAdjustmentBehavior.Never;
            TokenScrollView.Scrolled += OnScrolled;
            TokenScrollView.TranslatesAutoresizingMaskIntoConstraints = false;

            TokenPageControl.CurrentPageIndicatorTintColor = Theme.PrimaryColor;

            AddStartPage();
            AddRegisterPage();
            AddCopyPage();
            AddTestPage();

            View.LayoutIfNeeded();
        }

        protected override void Cleanup()
        {
            base.Cleanup();

            TokenScrollView.Scrolled -= OnScrolled;
        }

        protected override void BindControls()
        {
            base.BindControls();

            var set = this.CreateBindingSet<TokenViewController, TokenViewModel>();
            set.Bind(_startView.StartDescription).To(vm => vm.TokenStartText);
            set.Bind(_copyView.CopyDescription).To(vm => vm.TokenCopyText);
            set.Bind(_registerView.RegisterDescription).To(vm => vm.TokenRegisterText);

            set.Bind(_testView.TokenInput).To(vm => vm.ApiToken);
            set.Bind(_testView.TokenInput).For(v => v.Placeholder).To(vm => vm.ApiKeyPlaceholder);
            set.Bind(_testView.TokenInput).For(v => v.Enabled).To(vm => vm.ApiTextEnabled);

            set.Bind(_testView).For("ResultImageVisibility").To(vm => vm.TokenTested).OneWay();
            set.Bind(_testView.ResultImage).For(v => v.Image).To(vm => vm.TokenValid)
                .WithConversion("CheckIconConverter");

            set.Bind(_testView).For("InstructionHidden").To(vm => vm.TokenTested);
            set.Bind(_testView.InstructionText).To(vm => vm.TokenTestText);

            set.Bind(_testView).For("SuccessTextVisibility").To(vm => vm.ShowSuccess);
            set.Bind(_testView.SuccessText).To(vm => vm.TokenSuccessText);

            set.Bind(_testView).For("ErrorTextVisibility").To(vm => vm.ShowFailed);
            set.Bind(_testView.ErrorText).To(vm => vm.TokenFailedText);

            set.Bind(_testView.TestButton).To(vm => vm.SaveCommand);
            set.Bind(_testView.TestButton).For("Title").To(vm => vm.TestButtonText);

            set.Apply();
        }

        private void AddStartPage() 
        {
            _startView = new TokenStartSubView();

            TokenScrollView.AddSubview(_startView);

            _startView.TranslatesAutoresizingMaskIntoConstraints = false;
            _startView.TopAnchor.ConstraintEqualTo(TokenScrollView.TopAnchor).Active = true;
            _startView.LeadingAnchor.ConstraintEqualTo(TokenScrollView.LeadingAnchor).Active = true;
            _startView.BottomAnchor.ConstraintEqualTo(TokenScrollView.BottomAnchor).Active = true;
            _startView.HeightAnchor.ConstraintEqualTo(TokenScrollView.HeightAnchor).Active = true;
            _startView.WidthAnchor.ConstraintEqualTo(TokenScrollView.WidthAnchor).Active = true;
        }

        private void AddRegisterPage()
        {
            _registerView = new TokenRegisterSubView();

            TokenScrollView.AddSubview(_registerView);

            _registerView.TranslatesAutoresizingMaskIntoConstraints = false;
            _registerView.TopAnchor.ConstraintEqualTo(TokenScrollView.TopAnchor).Active = true;
            _registerView.LeadingAnchor.ConstraintEqualTo(_startView.TrailingAnchor).Active = true;
            _registerView.HeightAnchor.ConstraintEqualTo(TokenScrollView.HeightAnchor).Active = true;
            _registerView.WidthAnchor.ConstraintEqualTo(TokenScrollView.WidthAnchor).Active = true;
        }

        private void AddCopyPage()
        {
            _copyView = new TokenCopySubView();

            TokenScrollView.AddSubview(_copyView);

            _copyView.TranslatesAutoresizingMaskIntoConstraints = false;
            _copyView.TopAnchor.ConstraintEqualTo(TokenScrollView.TopAnchor).Active = true;
            _copyView.LeadingAnchor.ConstraintEqualTo(_registerView.TrailingAnchor).Active = true;
            _copyView.HeightAnchor.ConstraintEqualTo(TokenScrollView.HeightAnchor).Active = true;
            _copyView.WidthAnchor.ConstraintEqualTo(TokenScrollView.WidthAnchor).Active = true;
        }

        private void AddTestPage()
        {
            _testView = new TokenTestSubView();

            TokenScrollView.AddSubview(_testView);

            _testView.TranslatesAutoresizingMaskIntoConstraints = false;
            _testView.TopAnchor.ConstraintEqualTo(TokenScrollView.TopAnchor).Active = true;
            _testView.LeadingAnchor.ConstraintEqualTo(_copyView.TrailingAnchor).Active = true;
            _testView.TrailingAnchor.ConstraintEqualTo(TokenScrollView.TrailingAnchor).Active = true;
            _testView.HeightAnchor.ConstraintEqualTo(TokenScrollView.HeightAnchor).Active = true;
            _testView.WidthAnchor.ConstraintEqualTo(TokenScrollView.WidthAnchor).Active = true;
            _testView.TestButton.ApplyTheme(Theme.ButtonTheme);
        }

        private void OnScrolled(object sender, EventArgs e)
        {
            TokenPageControl.CurrentPage = (int)Math.Floor(TokenScrollView.ContentOffset.X / this.TokenScrollView.Frame.Size.Width);
        }
    }
}

