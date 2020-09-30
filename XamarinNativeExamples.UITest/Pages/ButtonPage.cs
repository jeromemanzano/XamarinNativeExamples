using NUnit.Framework;
using XamarinNativeExamples.Core.Properties;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace XamarinNativeExamples.UITest.Pages
{
    public class ButtonPage : BasePage
    {
        private readonly Query clickButton;
        private readonly Query clickCountLabel;
        private readonly Query longClickCountLabel;
        private readonly Query enableSwitch;
        private readonly string clickContainerId;
        private readonly string enableContainerId;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked(Resources.ButtonTitle),
            iOS = x => x.Marked(Resources.ButtonTitle)
        };

        public ButtonPage()
        {
            if (OnAndroid)
            {
                clickButton = x => x.Id("click_button");
                clickCountLabel = x => x.Id("click_counter");
                longClickCountLabel = x => x.Id("long_click_counter");
                enableSwitch = x => x.Id("enable_switch");
                clickContainerId = "button_click_frame";
                enableContainerId = "button_enable_frame";
            }

            if (OniOS)
            {
                clickButton = x => x.Marked("ClickButton");
                clickCountLabel = x => x.Marked("ClickCountLabel");
                longClickCountLabel = x => x.Marked("LongClickCountLabel");
                enableSwitch = x => x.Marked("EnableSwitch");
                clickContainerId = "ButtonClickViewController";
                enableContainerId = "ButtonEnableViewController";
            }
        }

        public ButtonPage OpenClickContainer() 
        {
            OpenContainer(clickContainerId);

            return this;
        }

        public ButtonPage OpenEnableContainer()
        {
            OpenContainer(enableContainerId);

            return this;
        }

        public ButtonPage PerformClick(int clickCount)
        {
            for (int i = 0; i < clickCount; i++)
            {
                App.Tap(clickButton);
            }

            return this;
        }

        public ButtonPage PerformLongClick(int longClickCount)
        {
            for (int i = 0; i < longClickCount; i++)
            {
                App.TouchAndHold(clickButton);
            }

            return this;
        }

        public ButtonPage VerifyClickCount(int clickCount) 
        {
            var displayedClickCount = int.Parse(App.Query(clickCountLabel)[0].Text);

            Assert.AreEqual(clickCount, displayedClickCount);
            return this;

        }

        public ButtonPage VerifyLongClickCount(int longClickCount)
        {
            var displayedLongClickCount = int.Parse(App.Query(longClickCountLabel)[0].Text);

            Assert.AreEqual(longClickCount, displayedLongClickCount);
            return this;
        }

        public ButtonPage EnableDisableButton() 
        {
            App.Tap(enableSwitch);
            return this;
        }
    }
}
