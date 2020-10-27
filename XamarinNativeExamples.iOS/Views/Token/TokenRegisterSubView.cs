using UIKit;

namespace XamarinNativeExamples.iOS.Views.Token
{
    public class TokenRegisterSubView : UIView
    {
        public TokenRegisterSubView()
        {
            Initialize();
        }

        public UILabel RegisterDescription { get; set; }

        public void Initialize() 
        {
            var tokenRegisterImage = new UIImageView();
            tokenRegisterImage.Image = UIImage.FromBundle("ApiTokenRegister");
            tokenRegisterImage.ContentMode = UIViewContentMode.ScaleAspectFit;
            RegisterDescription = new UILabel();

            AddSubview(tokenRegisterImage);
            AddSubview(RegisterDescription);

            tokenRegisterImage.TranslatesAutoresizingMaskIntoConstraints = false;
            tokenRegisterImage.TopAnchor.ConstraintEqualTo(SafeAreaLayoutGuide.TopAnchor, 40).Active = true;
            tokenRegisterImage.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 40).Active = true;
            tokenRegisterImage.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, -40).Active = true;

            RegisterDescription.TranslatesAutoresizingMaskIntoConstraints = false;
            RegisterDescription.TopAnchor.ConstraintEqualTo(tokenRegisterImage.BottomAnchor, 30).Active = true;
            RegisterDescription.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 40).Active = true;
            RegisterDescription.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, -40).Active = true;
            RegisterDescription.Lines = 0;
            RegisterDescription.LineBreakMode = UILineBreakMode.WordWrap;
        }
    }
}