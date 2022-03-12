using System.Linq;
using NUnit.Framework;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace XamarinNativeExamples.UITest.Pages
{
    public class HttpPage : BasePage
    {
        private readonly Query _clickButton;
        private readonly Query _sentimentLabel;
        private readonly Query _stockEditField;

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
                _clickButton = x => x.Id("click_button");
                _sentimentLabel = x => x.Id("sentiment_label");
                _stockEditField = x => x.Id("stock_edit_text");
            }

            if (OniOS)
            {
                //TODO: implement after iOS code
            }
        }

        public HttpPage EnterStock(string input)
        {
            App.Tap(_stockEditField);

            if (OnAndroid)
            {
                App.Query(x => x.Id("stock_edit_text")
                    .Invoke("setText", input));
            }
            else
            {
                App.EnterText(_stockEditField, input);
            }

            App.Tap(_clickButton);

            return this;
        }

        public void VerifyReceivedResponse()
        {
            var query = App.WaitForElement(_sentimentLabel);

            Assert.IsTrue(query.Any());
        }
    }
}
