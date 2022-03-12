using XamarinNativeExamples.Core.Managers.Stocks;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.ViewModels.Base;
using MvvmCross;
using MvvmCross.Commands;
using System.Threading.Tasks;
using System;
using XamarinNativeExamples.Core.Exceptions;
using System.Net.Http;

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
            private set
            {
                SetProperty(ref _stockSymbol, value);
                ButtonEnabled = !value.IsNullOrEmpty();
            }
        }
        
        private IMvxCommand _getNewSentimentCommand;
        public IMvxCommand GetNewsSentimentCommand => _getNewSentimentCommand ??= new MvxAsyncCommand(GetNewsSentimentAsync);

        public HttpViewModel() 
        {
            _stockManager = IoCProvider.Resolve<IStockManager>();
        }
        
        private async Task GetNewsSentimentAsync() 
        {
            try
            {
                SentimentsVisible = false;

                var newsSentimentsModel = await _stockManager.GetNewsSentimentAsync(StockSymbol);

                await InvokeOnMainThreadAsync(() =>
                {
                    ArticlesCount = string.Format(Resources.LastWeekArticlesFormat, newsSentimentsModel.Buzz.ArticlesInLastWeek);
                    ArticlesWeeklyCount = string.Format(Resources.WeeklyArticlesFormat, newsSentimentsModel.Buzz.WeeklyAverage);

                    SentimentValue = newsSentimentsModel.Sentiment.BullishPercent < .45 ? Resources.Bearish :
                        newsSentimentsModel.Sentiment.BullishPercent < .55 ? Resources.Neutral : Resources.Bullish;
                });

                SentimentsVisible = true;
            }
            catch (HttpRequestException hEx)
            {
                await Interactions.ShowDialogAsync(hEx.Message);
            }
            catch (BusinessException bEx) 
            { 
                await Interactions.ShowDialogAsync(bEx.Message);
            }
            catch (Exception)
            {
                await Interactions.ShowDialogAsync(Resources.UnknownErrorMessage);
            }
        }
    }
}
