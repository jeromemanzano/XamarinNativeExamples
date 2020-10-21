using MvvmCross;
using NUnit.Framework;
using Xamarin.UITest;
using XamarinNativeExamples.UITest.Pages;
using XamarinNativeExamples.Core.Managers.Stocks;

namespace XamarinNativeExamples.UITest.Tests
{
    public class CommunicationTests : BaseTestFixture
    {
        public CommunicationTests(Platform platform)
            : base(platform)
        {
        }

        [Test]
        public void HttpTest()
        {
            new HomePage()
                .NavigateToHttpPage();

            new TokenPage().
                SwipeToInput().
                TestApiKey("btv7rtf48v6qgbpjvci0").
                SaveToken();

            new HttpPage()
                .EnterStock("AAPL")
                .VerifyReceivedResponse();
        }

        [Test]
        public void WebSocketTest()
        {
            new HomePage()
                .NavigateToWebSocketPage();

            new TokenPage()
                .SwipeToInput()
                .TestApiKey("btv7rtf48v6qgbpjvci0")
                .SaveToken();

            new WebSocketPage()
                .Connect();
        }

        public override void BeforeEachTest()
        {
            base.BeforeEachTest();
        }
    }
}
