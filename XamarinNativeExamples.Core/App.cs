using AutoMapper;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using XamarinNativeExamples.Core.Managers.Interactions;
using XamarinNativeExamples.Core.Managers.Stocks;
using XamarinNativeExamples.Core.Services.RestServices;
using XamarinNativeExamples.Core.Services.RestServices.Base;
using XamarinNativeExamples.Core.Services.Storage;
using XamarinNativeExamples.Core.Services.WebSocketServices;
using XamarinNativeExamples.Core.Services.WebSocketServices.Base;
using XamarinNativeExamples.Core.Utils.Mappers;

namespace XamarinNativeExamples.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterCustomAppStart<AppStart>();

            RegisterServices();
            RegisterManagers();
            RegisterMapper();
        }

        private void RegisterManagers() 
        {
            Mvx.IoCProvider.RegisterSingleton<IStockManager>(() => Mvx.IoCProvider.IoCConstruct<StockManager>());
            Mvx.IoCProvider.RegisterSingleton<IInteractionManager>(() => Mvx.IoCProvider.IoCConstruct<InteractionManager>());
            Mvx.IoCProvider.RegisterSingleton<ISecuredStorage>(() => Mvx.IoCProvider.IoCConstruct<SecuredStorage>());
        }

        private void RegisterServices() 
        { 
            Mvx.IoCProvider.RegisterSingleton<IHttpClientFactory>(() => Mvx.IoCProvider.IoCConstruct<HttpClientFactory>());
            Mvx.IoCProvider.RegisterSingleton<IStockRestService>(() => Mvx.IoCProvider.IoCConstruct<StockRestService>());

            Mvx.IoCProvider.RegisterSingleton<IWebSocketFactory>(() => Mvx.IoCProvider.IoCConstruct<WebSocketFactory>());
            Mvx.IoCProvider.RegisterSingleton<IStockWebSocketService>(() => Mvx.IoCProvider.IoCConstruct<StockWebSocketService>());
        }

        private void RegisterMapper() 
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MessageModelProfile>();
            });

            Mvx.IoCProvider.RegisterSingleton(() => config.CreateMapper());
        }
    }
}
