using XamarinNativeExamples.Core.Properties;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace XamarinNativeExamples.UITest.Pages
{
    public class HomePage : BasePage
    {
        private readonly Query buttonCard;
        private readonly Query textCard;
        private readonly Query httpCard;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked(Resources.HomeTitle),
            iOS = x => x.Marked(Resources.HomeTitle)
        };

        public HomePage()
        {

            if (OnAndroid)
            {
                buttonCard = x => x.Id("button_card_view");
                textCard = x => x.Id("text_card_view");
                httpCard = x => x.Id("http_card_view");
            }

            if (OniOS)
            {
                buttonCard = x => x.Marked("ButtonButton");
                textCard = x => x.Marked("TextButton");
                //TODO:
                //httpCard = x => x.Id("HttpButton");
            }
        }

        public void NavigateToButtonPage() 
        {
            App.WaitForElement(buttonCard);
            App.Tap(buttonCard);
        }

        public void NavigateToTextPage()
        {
            App.WaitForElement(textCard);
            App.Tap(textCard);
        }

        public void NavigateToHttpPage()
        {
            App.WaitForElement(httpCard);
            App.Tap(httpCard);
        }
    }
}
