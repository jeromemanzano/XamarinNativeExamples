using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace XamarinNativeExamples.UITest.Pages
{
    public class WebSocketPage : BasePage
    {
        private readonly Query connectButton;
        private readonly Query pingLabel;
        private readonly Query stockEditField;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Id("connect_button"),
            //TODO: implement
            //iOS = x => x.Marked(Resources.ButtonTitle)
        };

        public WebSocketPage()
        {
            if (OnAndroid)
            {
                connectButton = x => x.Id("connect_button");
                pingLabel = x => x.Id("ping");
                stockEditField = x => x.Id("stock_edit_text");
            }

            if (OniOS)
            {
                //TODO: implement after iOS code
            }
        }

        public WebSocketPage Connect() 
        {
            App.Tap(connectButton);
            App.WaitForElement(pingLabel);
            return this;
        }
    }
}
