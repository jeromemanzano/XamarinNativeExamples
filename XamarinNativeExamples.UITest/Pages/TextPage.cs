using NUnit.Framework;
using XamarinNativeExamples.Core.Properties;
using System.Linq;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace XamarinNativeExamples.UITest.Pages
{
    public class TextPage : BasePage
    {
        private readonly Query _inputField;
        private readonly Query _displayedLabel;
        private readonly Query _displayedButton;
        private readonly Query _filterDropDown;
        private readonly string _textContainerId;
        private readonly string _textFilterContainerId;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked(Resources.TextTitle),
            iOS = x => x.Marked(Resources.TextTitle)
        };

        public TextPage() 
        {
            if (OnAndroid)
            {
                _inputField = x => x.Id("input_text");
                _displayedLabel = x => x.Id("text_label");
                _displayedButton = x => x.Id("click_button");
                _filterDropDown = x => x.Id("filter_spinner");
                _textContainerId = "text_text_frame";
                _textFilterContainerId = "text_filter_frame";
            }

            if (OniOS)
            {
                _inputField = x => x.Marked("InputTextField");
                _displayedLabel = x => x.Marked("InputDisplayLabel");
                _displayedButton = x => x.Marked("InputDisplayButton");
                _filterDropDown = x => x.Marked("FilterInputPickerTextField");
                _textContainerId = "TextTextViewController";
                _textFilterContainerId = "TextFilterViewController";
            }
        }

        public TextPage OpenTextContainer() 
        {
            OpenContainer(_textContainerId);

            return this;
        }

        public TextPage OpenFilterContainer() 
        {
            OpenContainer(_textFilterContainerId);

            return this;
        }

        public TextPage InputString(string input) 
        {
            App.Tap(_inputField);

            if (OnAndroid)
            {
                App.Query(x => x.Id("input_text")
                    .Invoke("setText", input));
            }
            else 
            {
                App.EnterText(_inputField, input);
            }

            App.DismissKeyboard();

            return this;
        }

        public TextPage SelectFilter(FilterTypes type) 
        {
            Query selectionQuery = x => x.Marked(type == FilterTypes.LowercaseOnly
                ? "Lower Case only" : "Numbers only");
            var selectionElement = App.Query(selectionQuery);

            if (!selectionElement.Any())
            {
                App.Tap(_filterDropDown);
                App.Tap(selectionQuery);
            }

            return this;
        }

        public TextPage VerifyDisplayedString(string input) 
        {
            var labelText = App.Query(_displayedLabel)[0].Text;
            var buttonText = App.Query(_displayedButton)[0].Text;

            Assert.AreEqual(labelText, input);
            Assert.AreEqual(buttonText, input);

            return this;
        }

        public TextPage VerifyFilteredDisplayString(string input, bool correct) 
        {
            var outputString = App.Query(_inputField)[0].Text;

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
