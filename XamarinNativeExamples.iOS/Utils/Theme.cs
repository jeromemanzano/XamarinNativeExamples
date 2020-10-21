using System;
using UIKit;

namespace XamarinNativeExamples.iOS.Utils
{
    public struct ButtonTheme 
    { 
        public UIColor BackgroundColor { get; set; }
        public UIColor TextColor { get; set; }
        public UIColor SelectedBackgroundColor { get; set; }
        public UIColor SelectedTextColor { get; set; }
        public UIColor DisabledBackgroundColor { get; set; }
        public UIColor DisabledTextColor { get; set; }
        public nfloat CornerRadius { get; set; }
        public UIFont Font { get; set; }
    }

    public struct NavigationTheme 
    { 
        public bool PrefersLargeTitles { get; set; }
        public UIImage BackgroundImage { get; set; }
        public UIColor BackgroundColor { get; set; }
        public UIColor TextColor { get; set; }
    }

    public struct AccordionTheme 
    { 
        public UIFont TitleFont { get; set; }
        public UIColor TitleTextColor { get; set; }
        public UIColor ToggleBackgroundColor { get; set; }
        public UIColor ToggleTextColor { get; set; }
        public UIColor BackgroundColor { get; set; }
        public nfloat CornerRadius { get; set; }
    }

    public struct ViewControllerTheme 
    {
        public ButtonTheme ButtonTheme { get; set; }
        public NavigationTheme NavigationTheme { get; set; }
        public AccordionTheme AccordionTheme { get; set; }
    }

    public static class Themes
    {
        public static ViewControllerTheme Home { get; } = new ViewControllerTheme 
        {
            NavigationTheme = new NavigationTheme 
            { 
                BackgroundColor = UIColor.FromName("PrussianBlue"),
                TextColor = UIColor.White
            }
        };

        public static ViewControllerTheme Button { get; } = new ViewControllerTheme
        {
            NavigationTheme = new NavigationTheme
            {
                BackgroundColor = UIColor.FromName("MustardYellow"),
                TextColor = UIColor.White,
                PrefersLargeTitles = true,
                BackgroundImage = UIImage.FromBundle("ButtonPanel").Blend(0.6f, UIColor.FromName("MustardYellow").CGColor),
            },
            ButtonTheme = new ButtonTheme
            {
                BackgroundColor = UIColor.FromName("TimberGreen"),
                TextColor = UIColor.White,
                DisabledBackgroundColor = UIColor.LightGray,
                DisabledTextColor = UIColor.DarkTextColor,
                CornerRadius = 5f,
                Font = UIFont.SystemFontOfSize(20f, UIFontWeight.Bold)
            },
            AccordionTheme = new AccordionTheme
            {
                TitleTextColor = UIColor.Black,
                TitleFont = UIFont.SystemFontOfSize(20f, UIFontWeight.Bold),
                ToggleBackgroundColor = UIColor.FromName("MustardYellow"),
                ToggleTextColor = UIColor.White,
                CornerRadius = 5f
            }
        };

        public static ViewControllerTheme Text { get; } = new ViewControllerTheme
        {
            NavigationTheme = new NavigationTheme
            {
                BackgroundColor = UIColor.FromName("ComoGreen"),
                TextColor = UIColor.White,
                PrefersLargeTitles = true,
                BackgroundImage = UIImage.FromBundle("TextPanel").Blend(0.6f, UIColor.FromName("ComoGreen").CGColor),
            },
            ButtonTheme = new ButtonTheme
            {
                BackgroundColor = UIColor.FromName("MountBattenPink"),
                TextColor = UIColor.White,
                DisabledBackgroundColor = UIColor.LightGray,
                DisabledTextColor = UIColor.DarkTextColor,
                CornerRadius = 5f,
                Font = UIFont.SystemFontOfSize(20f, UIFontWeight.Bold)
            },
            AccordionTheme = new AccordionTheme
            {
                TitleTextColor = UIColor.Black,
                TitleFont = UIFont.SystemFontOfSize(20f, UIFontWeight.Bold),
                ToggleBackgroundColor = UIColor.FromName("ComoGreen"),
                ToggleTextColor = UIColor.White,
                CornerRadius = 5f
            }
        };
    }
}