using System;
using UIKit;

namespace XamarinNativeExamples.iOS.Utils
{
    public struct ButtonTheme 
    { 
        public UIColor BackgroundColor { get; set; }
        public UIColor TextColor { get; set; }
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
        public UIColor PrimaryColor { get; set; }
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
            },
            PrimaryColor = UIColor.FromName("MustardYellow"),
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
            },
            PrimaryColor = UIColor.FromName("ComoGreen"),
        };

        public static ViewControllerTheme Token { get; } = new ViewControllerTheme
        {
            NavigationTheme = new NavigationTheme
            {
                BackgroundColor = UIColor.Clear,
                TextColor = UIColor.FromName("PrussianBlue"),
                BackgroundImage = new UIImage(),
            },
            ButtonTheme = new ButtonTheme
            {
                BackgroundColor = UIColor.FromName("PrussianBlue"),
                TextColor = UIColor.White,
                DisabledBackgroundColor = UIColor.LightGray,
                DisabledTextColor = UIColor.DarkTextColor,
                CornerRadius = 5f,
                Font = UIFont.SystemFontOfSize(20f, UIFontWeight.Bold)
            },
            PrimaryColor = UIColor.FromName("PrussianBlue"),
        };

        public static ViewControllerTheme Http { get; } = new ViewControllerTheme
        {
            NavigationTheme = new NavigationTheme
            {
                BackgroundColor = UIColor.FromName("PacificBlue"),
                TextColor = UIColor.White,
                PrefersLargeTitles = true,
                BackgroundImage = UIImage.FromBundle("HttpPanel").Blend(0.6f, UIColor.FromName("PacificBlue").CGColor),
            },
            ButtonTheme = new ButtonTheme
            {
                BackgroundColor = UIColor.FromName("DavysGrey"),
                TextColor = UIColor.White,
                DisabledBackgroundColor = UIColor.LightGray,
                DisabledTextColor = UIColor.DarkTextColor,
                CornerRadius = 5f,
                Font = UIFont.SystemFontOfSize(20f, UIFontWeight.Bold)
            },
            PrimaryColor = UIColor.FromName("PacificBlue"),
        };

        public static ViewControllerTheme WebSocket { get; } = new ViewControllerTheme
        {
            NavigationTheme = new NavigationTheme
            {
                BackgroundColor = UIColor.FromName("AlloyOrange"),
                TextColor = UIColor.White,
                PrefersLargeTitles = true,
                BackgroundImage = UIImage.FromBundle("WebSocketPanel").Blend(0.6f, UIColor.FromName("AlloyOrange").CGColor),
            },
            ButtonTheme = new ButtonTheme
            {
                BackgroundColor = UIColor.FromName("BlackChocolate"),
                TextColor = UIColor.White,
                DisabledBackgroundColor = UIColor.LightGray,
                DisabledTextColor = UIColor.DarkTextColor,
                CornerRadius = 5f,
                Font = UIFont.SystemFontOfSize(20f, UIFontWeight.Bold)
            },
            PrimaryColor = UIColor.FromName("AlloyOrange"),
        };
    }
}