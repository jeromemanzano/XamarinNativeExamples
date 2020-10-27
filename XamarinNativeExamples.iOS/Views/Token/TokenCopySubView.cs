using UIKit;

namespace XamarinNativeExamples.iOS.Views.Token
{
    public class TokenCopySubView : UIView
    {
        public TokenCopySubView()
        {
            Initialize();
        }

        public UILabel CopyDescription { get; set; }

        public void Initialize()
        {
            var tokenCopyImage = new UIImageView();
            tokenCopyImage.Image = UIImage.FromBundle("ApiTokenCopy");
            tokenCopyImage.ContentMode = UIViewContentMode.ScaleAspectFit;
            CopyDescription = new UILabel();

            AddSubview(tokenCopyImage);
            AddSubview(CopyDescription);

            tokenCopyImage.TranslatesAutoresizingMaskIntoConstraints = false;
            tokenCopyImage.TopAnchor.ConstraintEqualTo(SafeAreaLayoutGuide.TopAnchor, 40).Active = true;
            tokenCopyImage.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 40).Active = true;
            tokenCopyImage.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, -40).Active = true;

            CopyDescription.TranslatesAutoresizingMaskIntoConstraints = false;
            CopyDescription.TopAnchor.ConstraintEqualTo(tokenCopyImage.BottomAnchor, 30).Active = true;
            CopyDescription.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 40).Active = true;
            CopyDescription.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, -40).Active = true;
            CopyDescription.Lines = 0;
            CopyDescription.LineBreakMode = UILineBreakMode.WordWrap;
        }
    }
}