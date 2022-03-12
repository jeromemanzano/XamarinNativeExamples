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
        private readonly Query _connectButton;
        private readonly Query _pingLabel;
        private readonly Query _stockEditField;

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
                _connectButton = x => x.Id("connect_button");
                _pingLabel = x => x.Id("ping");
                _stockEditField = x => x.Id("stock_edit_text");
            }

            if (OniOS)
            {
                //TODO: implement after iOS code
            }
        }

        public WebSocketPage Connect() 
        {
            App.Tap(_connectButton);
            App.WaitForElement(_pingLabel);
            return this;
        }
    }
}
