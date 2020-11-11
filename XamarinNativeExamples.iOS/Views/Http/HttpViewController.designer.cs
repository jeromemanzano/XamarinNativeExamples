// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamarinNativeExamples.iOS.Views.Http
{
    [Register ("HttpViewController")]
    partial class HttpViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ArticlesHeader { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LastWeekCount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView MainScroll { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton RequestButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Sentiment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SentimentHeader { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField SymbolInput { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SymbolLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel WeeklyCount { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ArticlesHeader != null) {
                ArticlesHeader.Dispose ();
                ArticlesHeader = null;
            }

            if (LastWeekCount != null) {
                LastWeekCount.Dispose ();
                LastWeekCount = null;
            }

            if (MainScroll != null) {
                MainScroll.Dispose ();
                MainScroll = null;
            }

            if (RequestButton != null) {
                RequestButton.Dispose ();
                RequestButton = null;
            }

            if (Sentiment != null) {
                Sentiment.Dispose ();
                Sentiment = null;
            }

            if (SentimentHeader != null) {
                SentimentHeader.Dispose ();
                SentimentHeader = null;
            }

            if (SymbolInput != null) {
                SymbolInput.Dispose ();
                SymbolInput = null;
            }

            if (SymbolLabel != null) {
                SymbolLabel.Dispose ();
                SymbolLabel = null;
            }

            if (WeeklyCount != null) {
                WeeklyCount.Dispose ();
                WeeklyCount = null;
            }
        }
    }
}