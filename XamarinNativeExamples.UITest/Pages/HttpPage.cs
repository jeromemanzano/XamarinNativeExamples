using System.Linq;
using NUnit.Framework;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace XamarinNativeExamples.UITest.Pages
{
    public class HttpPage : BasePage
    {
        private readonly Query clickButton;
        private readonly Query sentimentLabel;
        private readonly Query stockEditField;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Id("stock_label"),
            //TODO: implement
            //iOS = x => x.Marked(Resources.ButtonTitle)
        };

        public HttpPage()
        {
            if (OnAndroid)
            {
                clickButton = x => x.Id("click_button");
                sentimentLabel = x => x.Id("sentiment_label");
                stockEditField = x => x.Id("stock_edit_text");
            }

            if (OniOS)
            {
                //TODO: implement after iOS code
            }
        }

        public HttpPage EnterStock(string input)
        {
            App.Tap(stockEditField);

            if (OnAndroid)
            {
                App.Query(x => x.Id("stock_edit_text")
                    .Invoke("setText", input));
            }
            else
            {
                App.EnterText(stockEditField, input);
            }

            App.Tap(clickButton);

            return this;
        }

        public void VerifyReceivedResponse()
        {
            var query = App.WaitForElement(sentimentLabel);

            Assert.IsTrue(query.Any());

            return;
        }
    }
}
