using XamarinNativeExamples.iOS.Controls;
using XamarinNativeExamples.iOS.Utils;

namespace UIKit
{
    public static class ThemeExtensions
    {
        public static void ApplyTheme(this UIButton button, ButtonTheme theme) 
        {
            if (theme.BackgroundColor != null)
            {
                var defaultBackground = theme.BackgroundColor.CreateImageFromColor();
                button.SetBackgroundImage(defaultBackground, UIControlState.Normal);
            }

            if (theme.TextColor != null)
            {
                button.SetTitleColor(theme.TextColor, UIControlState.Normal);
            }

            if (theme.Font != null)
            {
                button.Font = theme.Font;
            }

            if (theme.DisabledBackgroundColor != null)
            {
                var disabledBackground = theme.DisabledBackgroundColor.CreateImageFromColor();
                button.SetBackgroundImage(disabledBackground, UIControlState.Disabled);
            }

            button.Layer.CornerRadius = theme.CornerRadius;
            button.ClipsToBounds = true;
        }

        public static void ApplyTheme(this UINavigationBar navigationBar, NavigationTheme theme)
        {
            navigationBar.PrefersLargeTitles = theme.PrefersLargeTitles;

            var regularNavigationAppearance = new UINavigationBarAppearance();
            regularNavigationAppearance.BackgroundColor = theme.BackgroundColor;
            regularNavigationAppearance.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = theme.TextColor };
            navigationBar.StandardAppearance = regularNavigationAppearance;

            if (theme.PrefersLargeTitles)
            {
                var largeNavigationAppearance = new UINavigationBarAppearance();
                largeNavigationAppearance.BackgroundImageContentMode = UIViewContentMode.ScaleAspectFill;
                largeNavigationAppearance.BackgroundImage = theme.BackgroundImage;
                largeNavigationAppearance.ShadowColor = UIColor.Clear;
                largeNavigationAppearance.LargeTitleTextAttributes = new UIStringAttributes() { ForegroundColor = theme.TextColor };
                navigationBar.ScrollEdgeAppearance = largeNavigationAppearance;
            }

            navigationBar.TintColor = theme.TextColor;
        }

        public static void ApplyTheme(this AccordionView accordionView, AccordionTheme theme)
        {
            accordionView.BackgroundColor = theme.BackgroundColor ?? UIColor.White;
            accordionView.SetCornerRadius(theme.CornerRadius);

            if (theme.TitleFont != null)
            {
                accordionView.TitleFont = theme.TitleFont;
            }

            if (theme.TitleTextColor != null)
            {
                accordionView.TitleTextColor = theme.TitleTextColor;
            }

            if (theme.ToggleBackgroundColor != null)
            {
                accordionView.ToggleBackgroundColor = theme.ToggleBackgroundColor;
            }

            if (theme.ToggleTextColor != null)
            {
                accordionView.ToggleTextColor = theme.ToggleTextColor;
            }
        }
    }
}