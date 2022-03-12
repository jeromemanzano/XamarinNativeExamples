using NUnit.Framework;
using XamarinNativeExamples.Core.Properties;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace XamarinNativeExamples.UITest.Pages
{
    public class ButtonPage : BasePage
    {
        private readonly Query _clickButton;
        private readonly Query _clickCountLabel;
        private readonly Query _longClickCountLabel;
        private readonly Query _enableSwitch;
        private readonly string _clickContainerId;
        private readonly string _enableContainerId;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked(Resources.ButtonTitle),
            iOS = x => x.Marked(Resources.ButtonTitle)
        };

        public ButtonPage()
        {
            if (OnAndroid)
            {
                _clickButton = x => x.Id("click_button");
                _clickCountLabel = x => x.Id("click_counter");
                _longClickCountLabel = x => x.Id("long_click_counter");
                _enableSwitch = x => x.Id("enable_switch");
                _clickContainerId = "button_click_frame";
                _enableContainerId = "button_enable_frame";
            }

            if (OniOS)
            {
                _clickButton = x => x.Marked("ClickButton");
                _clickCountLabel = x => x.Marked("ClickCountLabel");
                _longClickCountLabel = x => x.Marked("LongClickCountLabel");
                _enableSwitch = x => x.Marked("EnableSwitch");
                _clickContainerId = "ButtonClickViewController";
                _enableContainerId = "ButtonEnableViewController";
            }
        }

        public ButtonPage OpenClickContainer() 
        {
            OpenContainer(_clickContainerId);

            return this;
        }

        public ButtonPage OpenEnableContainer()
        {
            OpenContainer(_enableContainerId);

            return this;
        }

        public ButtonPage PerformClick(int clickCount)
        {
            for (int i = 0; i < clickCount; i++)
            {
                App.Tap(_clickButton);
            }

            return this;
        }

        public ButtonPage PerformLongClick(int longClickCount)
        {
            for (int i = 0; i < longClickCount; i++)
            {
                App.TouchAndHold(_clickButton);
            }

            return this;
        }

        public ButtonPage VerifyClickCount(int clickCount) 
        {
            var displayedClickCount = int.Parse(App.Query(_clickCountLabel)[0].Text);

            Assert.AreEqual(clickCount, displayedClickCount);
            return this;

        }

        public ButtonPage VerifyLongClickCount(int longClickCount)
        {
            var displayedLongClickCount = int.Parse(App.Query(_longClickCountLabel)[0].Text);

            Assert.AreEqual(longClickCount, displayedLongClickCount);
            return this;
        }

        public ButtonPage EnableDisableButton() 
        {
            App.Tap(_enableSwitch);
            return this;
        }
    }
}
