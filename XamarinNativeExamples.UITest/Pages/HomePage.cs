using XamarinNativeExamples.Core.Properties;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace XamarinNativeExamples.UITest.Pages
{
    public class HomePage : BasePage
    {
        private readonly Query _buttonCard;
        private readonly Query _textCard;
        private readonly Query _httpCard;
        private readonly Query _webSocketCard;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked(Resources.HomeTitle),
            iOS = x => x.Marked(Resources.HomeTitle)
        };

        public HomePage()
        {

            if (OnAndroid)
            {
                _buttonCard = x => x.Id("button_card_view");
                _textCard = x => x.Id("text_card_view");
                _httpCard = x => x.Id("http_card_view");
                _webSocketCard = x => x.Id("websocket_card_view");
            }

            if (OniOS)
            {
                _buttonCard = x => x.Marked("ButtonButton");
                _textCard = x => x.Marked("TextButton");
                //TODO:
                //_httpCard = x => x.Id("HttpButton");
            }
        }

        public void NavigateToButtonPage() 
        {
            App.WaitForElement(_buttonCard);
            App.Tap(_buttonCard);
        }

        public void NavigateToTextPage()
        {
            App.WaitForElement(_textCard);
            App.Tap(_textCard);
        }

        public void NavigateToHttpPage()
        {
            App.WaitForElement(_httpCard);
            App.Tap(_httpCard);
        }

        public void NavigateToWebSocketPage()
        {
            App.WaitForElement(_webSocketCard);
            App.Tap(_webSocketCard);
        }
    }
}
