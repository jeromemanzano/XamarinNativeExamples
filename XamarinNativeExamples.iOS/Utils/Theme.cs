using UIKit;

namespace XamarinNativeExamples.iOS.Utils
{
    public struct Theme
    {
        public UIColor BarTintColor { get; set; }
        public UIColor TitleForegroundColor { get; set; }
    }

    public class Themes
    {
        public static Theme Home => new Theme 
        {
            BarTintColor = UIColor.FromName("PrussianBlue"),
            TitleForegroundColor = UIColor.White
        };
    }
}