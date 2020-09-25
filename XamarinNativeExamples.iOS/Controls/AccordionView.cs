using System;
using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views.Gestures;
using UIKit;
using XamarinNativeExamples.iOS.Helpers;

namespace XamarinNativeExamples.iOS.Controls
{
    [Register("AccordionView"), DesignTimeVisible(true)]
    public class AccordionView : UIView
    {
        private UILabel _titleLabel;
        private UIButton _toggleButton;
        private UIView _contentView;
        private UIImageView _arrowImage;

        private NSLayoutConstraint _toggleOpenConstraint;
        private NSLayoutConstraint _toggleCloseConstraint;

        private bool _open;

        public AccordionView()
        {
            Initialize();
        }

        public AccordionView(IntPtr p)
            : base(p)
        {
            Initialize();
        }

        public string TitleLabel
        {
            get => _titleLabel.Text;
            set => _titleLabel.Text = value;
        }

        public UIFont TitleFont
        {
            get => _titleLabel.Font;
            set => _titleLabel.Font = value;
        }

        public UIColor TitleTextColor
        {
            get => _titleLabel.TextColor;
            set => _titleLabel.TextColor = value;
        }

        public UIColor ToggleBackgroundColor
        {
            get => _toggleButton.BackgroundColor;
            set => _toggleButton.BackgroundColor = value;
        }

        public UIColor ToggleTextColor
        {
            get => _toggleButton.CurrentTitleColor;
            set => _toggleButton.SetTitleColor(value, UIControlState.Normal);
        }

        public MvxGestureRecognizerBehavior Toggle
        {
            get => _toggleButton.Tap();
        }

        public bool Open
        {
            get => _open;
            set 
            {
                _open = value;
                UIView.Animate(.2, 0, UIViewAnimationOptions.TransitionFlipFromTop, SetHeightAnchor, null);
            }
        }

        public void SetContent(UIView content) 
        {
            _contentView.AddSubview(content);

            content.LeadingAnchor.ConstraintEqualTo(_contentView.LeadingAnchor).Active = true;
            content.TrailingAnchor.ConstraintEqualTo(_contentView.TrailingAnchor).Active = true;
            content.TopAnchor.ConstraintEqualTo(_contentView.TopAnchor).Active = true;
            content.BottomAnchor.ConstraintEqualTo(_contentView.BottomAnchor).Active = true;
        }

        public void SetCornerRadius(nfloat cornerRadius)
        {
            Layer.CornerRadius = cornerRadius;
            Layer.ShadowRadius = cornerRadius;

            _toggleButton.Layer.CornerRadius = cornerRadius;
            _toggleButton.Layer.MaskedCorners = CACornerMask.MinXMaxYCorner | CACornerMask.MaxXMaxYCorner;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
        }

        private void Initialize() 
        {
            ClipsToBounds = true;

            _titleLabel = new UILabel();
            _titleLabel.Lines = 1;
            _titleLabel.TextAlignment = UITextAlignment.Center;
            _titleLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            _titleLabel.LayoutMargins = new UIEdgeInsets(10f, 10f, 10f, 10f);

            _contentView = new UIView();
            _contentView.TranslatesAutoresizingMaskIntoConstraints = false;

            _toggleButton = new UIButton();
            _toggleButton.TranslatesAutoresizingMaskIntoConstraints = false;

            _arrowImage = new UIImageView();
            _arrowImage.Image = UIImage.FromBundle("DownArrow");
            _arrowImage.ContentMode = UIViewContentMode.ScaleAspectFill;
            _arrowImage.TranslatesAutoresizingMaskIntoConstraints = false;

            AddSubview(_titleLabel);
            AddSubview(_contentView);
            AddSubview(_toggleButton);
            AddSubview(_arrowImage);

            _titleLabel.TopAnchor.ConstraintEqualTo(this.TopAnchor, 10f).Active = true;
            _titleLabel.LeadingAnchor.ConstraintEqualTo(this.LeadingAnchor, 10f).Active = true;
            _titleLabel.TrailingAnchor.ConstraintEqualTo(this.TrailingAnchor, -10f).Active = true;
            
            _contentView.TopAnchor.ConstraintEqualTo(_titleLabel.BottomAnchor, 10f).Active = true;
            _contentView.LeadingAnchor.ConstraintEqualTo(this.LeadingAnchor).Active = true;
            _contentView.TrailingAnchor.ConstraintEqualTo(this.TrailingAnchor).Active = true;
            _contentView.HeightAnchor.ConstraintGreaterThanOrEqualTo(0f).Active = true;

            _toggleButton.LeadingAnchor.ConstraintEqualTo(this.LeadingAnchor).Active = true;
            _toggleButton.TrailingAnchor.ConstraintEqualTo(this.TrailingAnchor).Active = true;

            _toggleOpenConstraint = _toggleButton.TopAnchor.ConstraintEqualTo(_contentView.BottomAnchor);
            _toggleCloseConstraint = _toggleButton.TopAnchor.ConstraintEqualTo(_titleLabel.BottomAnchor, 10f);

            _toggleButton.BottomAnchor.ConstraintEqualTo(this.BottomAnchor).Active = true;

            _arrowImage.TopAnchor.ConstraintEqualTo(_toggleButton.TopAnchor, 10.0f).Active = true;
            _arrowImage.TrailingAnchor.ConstraintEqualTo(_toggleButton.TrailingAnchor, -10.0f).Active = true;
            _arrowImage.BottomAnchor.ConstraintEqualTo(_toggleButton.BottomAnchor, -10.0f).Active = true;
            _arrowImage.HeightAnchor.ConstraintEqualTo(20f).Active = true;
            _arrowImage.WidthAnchor.ConstraintEqualTo(20f).Active = true;

            Layer.MasksToBounds = false;
            Layer.ShadowColor = UIColor.Black.CGColor;
            Layer.ShadowOffset = new CGSize(0f, 5f);
            Layer.ShadowOpacity = .2f;
        }

        private void ToggleOpenState(object sender, EventArgs e)
        {
            Open = !Open;
        }

        private void SetHeightAnchor() 
        {
            if (Open)
            {
                _toggleOpenConstraint.Active = true;
                _toggleCloseConstraint.Active = false;
                _contentView.Alpha = 1;
                _toggleButton.SetTitle(StringHelper.StringResource("AccordionClose"), UIControlState.Normal);
                _arrowImage.Transform = CGAffineTransform.MakeRotation((float)Math.PI);
            }
            else
            {
                _contentView.Alpha = 0;
                _toggleCloseConstraint.Active = true;
                _toggleOpenConstraint.Active = false;
                _toggleButton.SetTitle(StringHelper.StringResource("AccordionOpen"), UIControlState.Normal);
                _arrowImage.Transform = CGAffineTransform.MakeIdentity();
            }

            LayoutIfNeeded();
        }
    }
}