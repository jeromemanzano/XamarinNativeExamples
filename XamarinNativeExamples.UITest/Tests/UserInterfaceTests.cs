using NUnit.Framework;
using Xamarin.UITest;
using XamarinNativeExamples.UITest.Pages;

namespace XamarinNativeExamples.UITest.Tests
{
    public class UserInterfaceTests : BaseTestFixture
    {
        public UserInterfaceTests(Platform platform) 
            : base(platform)
        {
        }

        [Test]
        public void ButtonClickAndLongClickTest() 
        {
            var clickCount = 1;
            var longClickCount = 1;
            new HomePage()
                .NavigateToButtonPage();

            new ButtonPage()
                .OpenClickContainer()
                .PerformClick(clickCount)
                .PerformLongClick(longClickCount)
                .VerifyClickCount(clickCount)
                .VerifyLongClickCount(longClickCount);
        }

        [Test]
        public void ButtonEnableTest() 
        {
            var clickCount = 1;

            new HomePage()
                .NavigateToButtonPage();

            new ButtonPage()
                .OpenEnableContainer()
                .PerformClick(clickCount)
                .EnableDisableButton()
                .PerformClick(clickCount)
                .VerifyClickCount(clickCount);
        }

        [Test]
        public void TextDisplayTest() 
        {
            var stringSample = "1234abcd";

            new HomePage()
                .NavigateToTextPage();

            new TextPage()
                .OpenTextContainer()
                .InputString(stringSample)
                .VerifyDisplayedString(stringSample);
        }

        [Test]
        public void TextFilterTest() 
        {
            var numericString = "1234";
            var lowerCaseString = "abcd";

            new HomePage()
                .NavigateToTextPage();

            new TextPage()
                .OpenFilterContainer()
                .SelectFilter(FilterTypes.NumbersOnly)
                .InputString(numericString)
                .VerifyFilteredDisplayString(numericString, true)
                .InputString(lowerCaseString)
                .VerifyFilteredDisplayString(lowerCaseString, false)
                .SelectFilter(FilterTypes.LowercaseOnly)
                .InputString(numericString)
                .VerifyFilteredDisplayString(numericString, false)
                .InputString(lowerCaseString)
                .VerifyFilteredDisplayString(lowerCaseString, true);
        }
    }
}
