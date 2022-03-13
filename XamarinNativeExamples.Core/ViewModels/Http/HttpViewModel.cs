using XamarinNativeExamples.Core.Managers.Stocks;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.ViewModels.Base;
using MvvmCross;
using MvvmCross.Commands;
using System.Threading.Tasks;
using System;
using XamarinNativeExamples.Core.Exceptions;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using XamarinNativeExamples.Core.Managers.Interactions;

namespace XamarinNativeExamples.Core.ViewModels.Http
{
    public class HttpViewModel : BasePageViewModel
    {
        private readonly IStockManager _stockManager;
        
        public override string Title => string.Empty;
        public string GetNewsSentimentText => Resources.SendRequest;
        public string SentimentLabel => Resources.Sentiments;
        public string ArticlesLabel => Resources.Articles;
        public string StockSymbolLabel => Resources.StockSymbol;
        public string StockSymbolHint => Resources.StockSymbolHint;
        public string SentimentValue { get; private set; }
        public string ArticlesWeeklyCount { get; private set; }
        public string ArticlesCount { get; private set; }
        public bool SentimentsVisible { get; private set; }
        public bool ButtonEnabled { get; private set; }
        
        private string _stockSymbol;
        public string StockSymbol
        {
            get => _stockSymbol;
            set
            {
                SetProperty(ref _stockSymbol, value);
                ButtonEnabled = !value.IsNullOrEmpty();
            }
        }
            
        private IMvxAsyncCommand _getNewSentimentCommand;
        public IMvxAsyncCommand GetNewsSentimentCommand => _getNewSentimentCommand ??= new MvxAsyncCommand(GetNewsSentimentAsync);

        public HttpViewModel(ILoggerFactory loggerFactory, 
            IMvxNavigationService navigationService,
            IStockManager stockManager,
            IInteractionManager interactionManager)
            :base(loggerFactory, navigationService, interactionManager)
        {
            _stockManager = stockManager;
        }
        
        private async Task GetNewsSentimentAsync() 
        {
            try
            {
                SentimentsVisible = false;

                var newsSentimentsModel = await _stockManager.GetNewsSentimentAsync(StockSymbol);

                ArticlesCount = string.Format(Resources.LastWeekArticlesFormat,
                    newsSentimentsModel.Buzz.ArticlesInLastWeek);
                ArticlesWeeklyCount =
                    string.Format(Resources.WeeklyArticlesFormat, newsSentimentsModel.Buzz.WeeklyAverage);

                SentimentValue = newsSentimentsModel.Sentiment.BullishPercent < .45 ? Resources.Bearish :
                    newsSentimentsModel.Sentiment.BullishPercent < .55 ? Resources.Neutral : Resources.Bullish;

                SentimentsVisible = true;
            }
            catch (Exception exception) when (exception is HttpRequestException or BusinessException)
            {
                await Interactions.ShowDialogAsync(exception.Message);
            }
            catch (Exception)
            {
                await Interactions.ShowDialogAsync(Resources.UnknownErrorMessage);
            }
        }
    }
}
