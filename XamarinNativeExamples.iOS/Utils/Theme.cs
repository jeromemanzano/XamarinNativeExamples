using UIKit;

namespace XamarinNativeExamples.iOS.Utils
{
    public struct Theme
    {
        public UIColor NavigationBackground { get; set; }
        public UIColor NavigationTextColor { get; set; }
        public UIColor ButtonBackgroundColor { get; set; }
        public UIColor ButtonTextColor { get; set; }
        public UIImage LargeTitleNavigationBackground { get; set; }
    }

    public class Themes
    {
        public static Theme Home => new Theme 
        {
            NavigationBackground = UIColor.FromName("PrussianBlue"),
            NavigationTextColor = UIColor.White
        };

        public static Theme Button => new Theme
        {
            NavigationBackground = UIColor.FromName("MustardYellow"),
            NavigationTextColor = UIColor.White,
            ButtonBackgroundColor = UIColor.FromName("TimberGreen"),
            ButtonTextColor = UIColor.White,
            LargeTitleNavigationBackground = UIImage.FromBundle("ButtonPanel")
        };
    }
}