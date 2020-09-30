using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinNativeExamples.Core.Properties;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace XamarinNativeExamples.UITest.Pages
{
    public class HomePage : BasePage
    {
        private readonly Query buttonClickButton;
        private readonly Query buttonEnableButton;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked(Resources.HomeTitle),
            iOS = x => x.Marked(Resources.HomeTitle)
        };

        public HomePage()
        {

            if (OnAndroid)
            {
                buttonClickButton = x => x.Id("button_card_view");
                buttonEnableButton = x => x.Id("text_card_view");
            }

            if (OniOS)
            {
                buttonClickButton = x => x.Marked("ButtonButton");
                buttonEnableButton = x => x.Marked("TextButton");
            }
        }

        public void NavigateToButtonPage() 
        {
            App.WaitForElement(buttonClickButton);
            App.Tap(buttonClickButton);
        }

        public void NavigateToTextPage()
        {
            App.WaitForElement(buttonEnableButton);
            App.Tap(buttonEnableButton);
        }
    }
}
