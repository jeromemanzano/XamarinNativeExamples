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

        public HttpViewModel() 
        {
            _stockManager = Mvx.IoCProvider.Resolve<IStockManager>();
        }

        private IMvxCommand _getNewSentimentCommand;
        public IMvxCommand GetNewsSentimentCommand
        {
            get => _getNewSentimentCommand ?? (_getNewSentimentCommand = new MvxAsyncCommand(GetNewsSentiment));
        }

        private string _stockSymbol;
        public string StockSymbol
        {
            get => _stockSymbol;
            private set => SetProperty(ref _stockSymbol, value);
        }

        private string _sentimentValue;
        public string SentimentValue
        {
            get => _sentimentValue;
            private set => SetProperty(ref _sentimentValue, value);
        }

        private string _articlesWeeklyCount;
        public string ArticlesWeeklyCount
        {
            get => _articlesWeeklyCount;
            private set => SetProperty(ref _articlesWeeklyCount, value);
        }

        private string _articlesCount;
        public string ArticlesCount
        {
            get => _articlesCount;
            private set => SetProperty(ref _articlesCount, value);
        }

        private bool _sentimentsVisible;
        public bool SentimentsVisible
        {
            get => _sentimentsVisible;
            private set => SetProperty(ref _sentimentsVisible, value);
        }
        
        public string GetNewsSentimentText => Resources.SendRequest;

        public string SentimentLabel => Resources.Sentiments;

        public string ArticlesLabel => Resources.Articles;

        public string StockSymbolLabel => Resources.StockSymbol;

        public string StockSymbolHint => Resources.StockSymbolHint;

        private async Task GetNewsSentiment() 
        {
            try
            {
                SentimentsVisible = false;

                var newsSentimentsModel = await _stockManager.GetNewsSentiment(StockSymbol);

                InvokeOnMainThread(() =>
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
                Interactions.ShowDialog(hEx.Message);
            }
            catch (BusinessException bEx) 
            { 
                Interactions.ShowDialog(bEx.Message);
            }
            catch (Exception e)
            {
                Interactions.ShowDialog(Resources.UnknownErrorMessage);
            }
        }
    }
}
