using UIKit;

namespace XamarinNativeExamples.iOS.Views.Token
{
    public class TokenStartSubView : UIView
    {
        public TokenStartSubView() 
        {
            Initialize();
        }

        public UILabel StartDescription { get; set; }

        private void Initialize() 
        {
            var tokenStartImage = new UIImageView();
            tokenStartImage.Image = UIImage.FromBundle("ApiTokenStart");
            tokenStartImage.ContentMode = UIViewContentMode.ScaleAspectFit;

            StartDescription = new UILabel();

            AddSubview(tokenStartImage);
            AddSubview(StartDescription);

            tokenStartImage.TranslatesAutoresizingMaskIntoConstraints = false;
            tokenStartImage.TopAnchor.ConstraintEqualTo(SafeAreaLayoutGuide.TopAnchor, 40).Active = true;
            tokenStartImage.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 40).Active = true;
            tokenStartImage.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, -40).Active = true;

            StartDescription.TranslatesAutoresizingMaskIntoConstraints = false;
            StartDescription.TopAnchor.ConstraintEqualTo(tokenStartImage.BottomAnchor, 30).Active = true;
            StartDescription.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 40).Active = true;
            StartDescription.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, -40).Active = true;
            StartDescription.Lines = 0;
            StartDescription.LineBreakMode = UILineBreakMode.WordWrap;
        }
    }
}