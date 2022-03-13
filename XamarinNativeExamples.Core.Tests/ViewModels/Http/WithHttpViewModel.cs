using System;
using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using XamarinNativeExamples.Core.Exceptions;
using XamarinNativeExamples.Core.Managers.Stocks;
using XamarinNativeExamples.Core.Models;
using XamarinNativeExamples.Core.Properties;
using XamarinNativeExamples.Core.ViewModels.Http;

namespace XamarinNativeExamples.Core.Tests.ViewModels.Http
{
    [TestFixture]
    public class WithHttpViewModel : BasePageViewModelTest<HttpViewModel>
    {
        private Mock<IStockManager> _stockManager;

        [Test]
        public async Task GetNewsSentimentCommand_Should_Execute_GetNewSentiment()
        {
            var stockSymbol = "a";
            ViewModel.StockSymbol = stockSymbol;
            
            await ViewModel.GetNewsSentimentCommand.ExecuteAsync();
            
            _stockManager.Verify(manager => manager.GetNewsSentimentAsync(stockSymbol), Times.Once);
        }

        [Test]
        public async Task GetNewsSentimentCommand_Should_Use_Buzz_Values()
        {
            var newsSentimentModel = new NewsSentimentModel()
            {
                Buzz = new BuzzModel()
                {
                    ArticlesInLastWeek = 1,
                    WeeklyAverage = 2
                }
            };
            
            _stockManager
                .Setup(manager => manager.GetNewsSentimentAsync(It.IsAny<string>()))
                .ReturnsAsync(newsSentimentModel);

            await ViewModel.GetNewsSentimentCommand.ExecuteAsync();
            
            _stockManager.Verify(manager => manager.GetNewsSentimentAsync(It.IsAny<string>()), Times.Once);
            Assert.AreEqual(string.Format(Resources.LastWeekArticlesFormat, newsSentimentModel.Buzz.ArticlesInLastWeek), ViewModel.ArticlesCount);
            Assert.AreEqual(string.Format(Resources.WeeklyArticlesFormat, newsSentimentModel.Buzz.WeeklyAverage), ViewModel.ArticlesWeeklyCount);
        }
        
        [TestCase(.44)]
        [TestCase(.45)]
        [TestCase(.54)]
        [TestCase(.55)]
        [TestCase(1)]
        public async Task GetNewsSentimentCommand_Should_Update_Sentiment_Value(double bullishPercent)
        {
            var newsSentimentModel = new NewsSentimentModel()
            {
                Buzz = new BuzzModel(),
                Sentiment = new SentimentModel()
                {
                    BullishPercent = bullishPercent
                }
            };
            
            _stockManager
                .Setup(manager => manager.GetNewsSentimentAsync(It.IsAny<string>()))
                .ReturnsAsync(newsSentimentModel);

            await ViewModel.GetNewsSentimentCommand.ExecuteAsync();
            
            _stockManager.Verify(manager => manager.GetNewsSentimentAsync(It.IsAny<string>()), Times.Once);

            if (bullishPercent < .45)
                Assert.AreEqual(Resources.Bearish, ViewModel.SentimentValue);
            else if (bullishPercent < .55)
                Assert.AreEqual(Resources.Neutral, ViewModel.SentimentValue);
            else
                Assert.AreEqual(Resources.Bullish, ViewModel.SentimentValue);
        }

        [TestCaseSource(nameof(GetKnownExceptions), new object[] {"exception message"})]
        public async Task Should_Show_Dialog_With_Exception_Message_When_Exception_Is_HttpRequestException_Or_BusinessException(Exception exception)
        {
            _stockManager
                .Setup(manager => manager.GetNewsSentimentAsync(It.IsAny<string>()))
                .ThrowsAsync(exception);
            
            await ViewModel.GetNewsSentimentCommand.ExecuteAsync();

            InteractionManager.Verify(manager => manager.ShowDialogAsync(exception.Message, null, null), Times.Once);
        }
        
        [TestCaseSource(nameof(GetUnknownExceptions))]
        public async Task Should_Show_Dialog_With_Unknown_Error_Message_When_Exception_Is_Not_HttpRequestException_Or_BusinessException(Exception exception)
        {
            _stockManager
                .Setup(manager => manager.GetNewsSentimentAsync(It.IsAny<string>()))
                .ThrowsAsync(exception);
            
            await ViewModel.GetNewsSentimentCommand.ExecuteAsync();

            InteractionManager.Verify(manager => manager.ShowDialogAsync(Resources.UnknownErrorMessage, null, null), Times.Once);
        }
        
        protected override HttpViewModel CreateViewModel()
        {
            _stockManager = new Mock<IStockManager>();
            return new HttpViewModel(null, NavigationService.Object, _stockManager.Object, InteractionManager.Object);
        }

        private static IEnumerable GetKnownExceptions(string message)
        {
            yield return new HttpRequestException(message);
            yield return new BusinessException(message);
        }
        
        private static IEnumerable GetUnknownExceptions()
        {
            yield return new NullReferenceException();
            yield return new ArgumentException();
            yield return new TimeoutException();
        }
    }
}