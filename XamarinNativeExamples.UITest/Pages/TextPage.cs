using NUnit.Framework;
using XamarinNativeExamples.Core.Properties;
using System.Linq;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace XamarinNativeExamples.UITest.Pages
{
    public class TextPage : BasePage
    {
        private readonly Query inputField;
        private readonly Query displayedLabel;
        private readonly Query displayedButton;
        private readonly Query filterDropDown;
        private readonly string textContainerId;
        private readonly string textFilterContainerId;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked(Resources.TextTitle),
            iOS = x => x.Marked(Resources.TextTitle)
        };

        public TextPage() 
        {
            if (OnAndroid)
            {
                inputField = x => x.Id("input_text");
                displayedLabel = x => x.Id("text_label");
                displayedButton = x => x.Id("click_button");
                filterDropDown = x => x.Id("filter_spinner");
                textContainerId = "text_text_frame";
                textFilterContainerId = "text_filter_frame";
            }

            if (OniOS)
            {
                inputField = x => x.Marked("InputTextField");
                displayedLabel = x => x.Marked("InputDisplayLabel");
                displayedButton = x => x.Marked("InputDisplayButton");
                filterDropDown = x => x.Marked("FilterInputPickerTextField");
                textContainerId = "TextTextViewController";
                textFilterContainerId = "TextFilterViewController";
            }
        }

        public TextPage OpenTextContainer() 
        {
            OpenContainer(textContainerId);

            return this;
        }

        public TextPage OpenFilterContainer() 
        {
            OpenContainer(textFilterContainerId);

            return this;
        }

        public TextPage InputString(string input) 
        {
            App.Tap(inputField);

            if (OnAndroid)
            {
                App.Query(x => x.Id("input_text")
                    .Invoke("setText", input));
            }
            else 
            {
                App.EnterText(inputField, input);
            }

            App.DismissKeyboard();

            return this;
        }

        public TextPage SelectFilter(FilterTypes type) 
        {
            Query selectionQuery = x => x.Marked(type == FilterTypes.LowercaseOnly
                ? "Lower Case only" : "Numbers only");
            var selectionElement = App.WaitForElement(selectionQuery);

            if (!selectionElement.Any())
            {
                App.Tap(filterDropDown);
                App.Tap(selectionQuery);
            }

            return this;
        }

        public TextPage VerifyDisplayedString(string input) 
        {
            var labelText = App.Query(displayedLabel)[0].Text;
            var buttonText = App.Query(displayedButton)[0].Text;

            Assert.AreEqual(labelText, input);
            Assert.AreEqual(buttonText, input);

            return this;
        }

        public TextPage VerifyFilteredDisplayString(string input, bool correct) 
        {
            var outputString = App.Query(inputField)[0].Text;

            Assert.IsTrue((input == outputString) == correct);

            return this;
        }
    }

    public enum FilterTypes 
    { 
        NumbersOnly,
        LowercaseOnly
    }
}
