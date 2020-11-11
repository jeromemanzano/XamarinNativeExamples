using UIKit;
using XamarinNativeExamples.iOS.Utils;
using XamarinNativeExamples.iOS.Views.Base;
using MvvmCross.Binding.BindingContext;
using XamarinNativeExamples.Core.ViewModels.WebSocket;

namespace XamarinNativeExamples.iOS.Views.WebSocket
{
    public partial class WebSocketViewController : BaseViewController<WebSocketViewModel>
    {
        protected override ViewControllerTheme Theme => Themes.WebSocket;

        public WebSocketViewController() : base("WebSocketViewController")
        {
        }

        protected override void InitializeControls()
        {
            base.InitializeControls();

            EdgesForExtendedLayout = UIRectEdge.None;

            ConnectButton.ApplyTheme(Theme.ButtonTheme);
            SubscribeButton.ApplyTheme(Theme.ButtonTheme);
            MainScrollView = MainScroll;
        }

        protected override void BindControls()
        {
            base.BindControls();

            var set = this.CreateBindingSet<WebSocketViewController, WebSocketViewModel>();

            set.Bind(ConnectButton).To(vm => vm.ConnectionCommand);
            set.Bind(ConnectButton)
                .For("Title")
                .To(vm => vm.ConnectButtonText);

            set.Bind(SubscribeButton).To(vm => vm.SubscribeCommand);
            set.Bind(SubscribeButton)
                .For("Visibility")
                .To(vm => vm.ShowStockDetails)
                .WithConversion("Visibility");
            set.Bind(SubscribeButton)
                .For("Title")
                .To(vm => vm.SubscribeText);

            set.Bind(PingLabel).To(vm => vm.PingCount);

            set.Bind(SymbolInput).To(vm => vm.InputStockSymbol);
            set.Bind(SymbolInput)
                .For("Visibility")
                .To(vm => vm.ShowStockDetails)
                .WithConversion("Visibility");

            set.Bind(PriceLabel).To(vm => vm.Price);
            set.Bind(PriceLabel)
                .For("Visibility")
                .To(vm => vm.ShowStockDetails)
                .WithConversion("Visibility");

            set.Bind(VolumeLabel).To(vm => vm.Volume);
            set.Bind(VolumeLabel)
                .For("Visibility")
                .To(vm => vm.ShowStockDetails)
                .WithConversion("Visibility");

            set.Bind(TimeLabel).To(vm => vm.Time);
            set.Bind(TimeLabel)
                .For("Visibility")
                .To(vm => vm.ShowStockDetails)
                .WithConversion("Visibility");

            set.Apply();
        }
    }
}

