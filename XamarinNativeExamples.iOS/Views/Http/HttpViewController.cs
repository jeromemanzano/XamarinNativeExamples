using UIKit;
using XamarinNativeExamples.Core.ViewModels.Http;
using XamarinNativeExamples.iOS.Utils;
using XamarinNativeExamples.iOS.Views.Base;
using MvvmCross.Binding.BindingContext;

namespace XamarinNativeExamples.iOS.Views.Http
{
    public partial class HttpViewController : BaseViewController<HttpViewModel>
    {
        protected override ViewControllerTheme Theme => Themes.Http;

        public HttpViewController() : base("HttpViewController")
        {
        }

        protected override void InitializeControls()
        {
            base.InitializeControls();

            EdgesForExtendedLayout = UIRectEdge.None;
            RequestButton.ApplyTheme(Theme.ButtonTheme);
            MainScrollView = MainScroll;
        }

        protected override void BindControls()
        {
            base.BindControls();

            var set = this.CreateBindingSet<HttpViewController, HttpViewModel>();
            set.Bind(SymbolLabel).To(vm => vm.StockSymbolLabel);

            set.Bind(SymbolInput).To(vm => vm.StockSymbol);
            set.Bind(SymbolInput).For(v => v.Placeholder).To(vm => vm.StockSymbolHint);

            set.Bind(RequestButton).To(vm => vm.GetNewsSentimentCommand);
            set.Bind(RequestButton).For("Title").To(vm => vm.GetNewsSentimentText);
            set.Bind(RequestButton).For(v => v.Enabled).To(vm => vm.ButtonEnabled);

            set.Bind(ArticlesHeader).To(vm => vm.ArticlesLabel);
            set.Bind(ArticlesHeader)
                .For("Visibility")
                .To(vm => vm.SentimentsVisible)
                .WithConversion("Visibility");

            set.Bind(LastWeekCount).To(vm => vm.ArticlesCount);
            set.Bind(LastWeekCount)
                .For("Visibility")
                .To(vm => vm.SentimentsVisible)
                .WithConversion("Visibility");

            set.Bind(WeeklyCount).To(vm => vm.ArticlesWeeklyCount);
            set.Bind(WeeklyCount)
                .For("Visibility")
                .To(vm => vm.SentimentsVisible)
                .WithConversion("Visibility");

            set.Bind(SentimentHeader).To(vm => vm.SentimentLabel);
            set.Bind(SentimentHeader)
                .For("Visibility")
                .To(vm => vm.SentimentsVisible)
                .WithConversion("Visibility");
            set.Bind(Sentiment).To(vm => vm.SentimentValue);
            set.Bind(Sentiment)
                .For("Visibility")
                .To(vm => vm.SentimentsVisible)
                .WithConversion("Visibility");

            set.Apply();
        }
    }
}

