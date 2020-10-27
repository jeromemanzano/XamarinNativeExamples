using UIKit;

namespace XamarinNativeExamples.iOS.Views.Token
{
    public class TokenTestSubView : UIView
    {
        public TokenTestSubView() 
        {
            Initialize();
        }

        public UITextField TokenInput { get; set; }

        public UIImageView ResultImage { get; set; }

        public UILabel SuccessText { get; set; }

        public UILabel ErrorText { get; set; }

        public UILabel InstructionText { get; set; }

        public UIButton TestButton { get; set; }

        public bool ResultImageVisibility 
        {
            set => ResultImage.Hidden = !value;
        }

        public bool SuccessTextVisibility
        {
            set => SuccessText.Hidden = !value;
        }

        public bool ErrorTextVisibility
        {
            set => ErrorText.Hidden = !value;
        }

        public bool InstructionHidden
        {
            set => InstructionText.Hidden = value;
        }

        public void Initialize() 
        {
            TokenInput = new UITextField();
            ResultImage = new UIImageView();
            SuccessText = new UILabel();
            ErrorText = new UILabel();
            InstructionText = new UILabel();
            TestButton = new UIButton();

            AddSubview(TokenInput);

            TokenInput.ContentMode = UIViewContentMode.ScaleToFill;

            TokenInput.TranslatesAutoresizingMaskIntoConstraints = false;
            TokenInput.HeightAnchor.ConstraintEqualTo(35).Active = true;
            TokenInput.TopAnchor.ConstraintEqualTo(SafeAreaLayoutGuide.TopAnchor, 40).Active = true;
            TokenInput.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 20).Active = true;
            TokenInput.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, -20).Active = true;
            TokenInput.BorderStyle = UITextBorderStyle.RoundedRect;

            AddSubview(ResultImage);
            ResultImage.ContentMode = UIViewContentMode.ScaleAspectFit;
            ResultImage.TranslatesAutoresizingMaskIntoConstraints = false;
            ResultImage.CenterYAnchor.ConstraintEqualTo(TokenInput.CenterYAnchor).Active = true;
            ResultImage.TrailingAnchor.ConstraintEqualTo(TokenInput.TrailingAnchor, -10).Active = true;
            ResultImage.HeightAnchor.ConstraintEqualTo(20).Active = true;
            ResultImage.WidthAnchor.ConstraintEqualTo(20).Active = true;

            AddSubview(SuccessText);
            SuccessText.Lines = 0;
            SuccessText.LineBreakMode = UILineBreakMode.WordWrap;
            SuccessText.TranslatesAutoresizingMaskIntoConstraints = false;
            SuccessText.TopAnchor.ConstraintEqualTo(TokenInput.BottomAnchor, 30).Active = true;
            SuccessText.LeadingAnchor.ConstraintEqualTo(TokenInput.LeadingAnchor).Active = true;
            SuccessText.TrailingAnchor.ConstraintEqualTo(TokenInput.TrailingAnchor).Active = true;

            AddSubview(ErrorText);
            ErrorText.Lines = 0;
            ErrorText.LineBreakMode = UILineBreakMode.WordWrap;
            ErrorText.TranslatesAutoresizingMaskIntoConstraints = false;
            ErrorText.TopAnchor.ConstraintEqualTo(SuccessText.TopAnchor).Active = true;
            ErrorText.LeadingAnchor.ConstraintEqualTo(TokenInput.LeadingAnchor).Active = true;
            ErrorText.TrailingAnchor.ConstraintEqualTo(TokenInput.TrailingAnchor).Active = true;

            AddSubview(InstructionText);
            InstructionText.Lines = 0;
            InstructionText.LineBreakMode = UILineBreakMode.WordWrap;
            InstructionText.TranslatesAutoresizingMaskIntoConstraints = false;
            InstructionText.TopAnchor.ConstraintEqualTo(SuccessText.TopAnchor).Active = true;
            InstructionText.LeadingAnchor.ConstraintEqualTo(TokenInput.LeadingAnchor).Active = true;
            InstructionText.TrailingAnchor.ConstraintEqualTo(TokenInput.TrailingAnchor).Active = true;

            AddSubview(TestButton);
            TestButton.TranslatesAutoresizingMaskIntoConstraints = false;
            TestButton.BackgroundColor = UIColor.Black;
            TestButton.BottomAnchor.ConstraintEqualTo(BottomAnchor, -100).Active = true;
            TestButton.LeadingAnchor.ConstraintEqualTo(TokenInput.LeadingAnchor).Active = true;
            TestButton.TrailingAnchor.ConstraintEqualTo(TokenInput.TrailingAnchor).Active = true;
            TestButton.HeightAnchor.ConstraintEqualTo(40).Active = true;
            TestButton.Layer.CornerRadius = 10;
        }
    }
}