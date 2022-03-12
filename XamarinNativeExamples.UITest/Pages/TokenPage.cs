using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace XamarinNativeExamples.UITest.Pages
{
    public class TokenPage : BasePage
    {
        private readonly Query _startScreen;
        private readonly Query _registerScreen;
        private readonly Query _copyScreen;
        private readonly Query _tokenField;
        private readonly Query _submitButton;
        private readonly Query _successText;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Id("img_api_token"),
            iOS = x => x.Marked("")
        };

        public TokenPage()
        {
            if (OnAndroid)
            {
                _startScreen = x => x.Id("img_api_token");
                _registerScreen = x => x.Id("img_api_register");
                _copyScreen = x => x.Id("img_copy_token");
                _tokenField = x => x.Id("token_edit_text");
                _submitButton = x => x.Id("save_button");
                _successText = x => x.Id("success_text");
            }

            if (OniOS)
            {
            }
        }

        public TokenPage SwipeToInput()
        {
            App.SwipeRightToLeft();
            App.WaitForElement(_registerScreen);
            App.SwipeRightToLeft();
            App.WaitForElement(_copyScreen);
            App.SwipeRightToLeft();

            return this;
        }

        public TokenPage TestApiKey(string apiKey)
        {
            if (OnAndroid)
            {
                App.Query(x => x.Id("token_edit_text")
                .Invoke("setText", apiKey));
            }

            App.Tap(_submitButton);

            return this;
        }

        public void SaveToken() 
        {
            App.WaitForElement(_successText);
            App.Tap(_submitButton);
        }
    }
}
