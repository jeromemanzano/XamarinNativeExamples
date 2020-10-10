using NUnit.Framework;
using Xamarin.UITest;
using XamarinNativeExamples.UITest.Pages;

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

            new HttpPage()
                .EnterStock("AAPL")
                .VerifyReceivedResponse();
        }
    }
}
