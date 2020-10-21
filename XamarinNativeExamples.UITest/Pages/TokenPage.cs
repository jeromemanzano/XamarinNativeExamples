using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace XamarinNativeExamples.UITest.Pages
{
    public class TokenPage : BasePage
    {
        private readonly Query startScreen;
        private readonly Query registerScreen;
        private readonly Query copyScreen;
        private readonly Query tokenField;
        private readonly Query submitButton;
        private readonly Query successText;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Id("img_api_token"),
            iOS = x => x.Marked("")
        };

        public TokenPage()
        {
            if (OnAndroid)
            {
                startScreen = x => x.Id("img_api_token");
                registerScreen = x => x.Id("img_api_register");
                copyScreen = x => x.Id("img_copy_token");
                tokenField = x => x.Id("token_edit_text");
                submitButton = x => x.Id("save_button");
                successText = x => x.Id("success_text");
            }

            if (OniOS)
            {
            }
        }

        public TokenPage SwipeToInput()
        {
            App.SwipeRightToLeft();
            App.WaitForElement(registerScreen);
            App.SwipeRightToLeft();
            App.WaitForElement(copyScreen);
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

            App.Tap(submitButton);

            return this;
        }

        public void SaveToken() 
        {
            App.WaitForElement(successText);
            App.Tap(submitButton);
        }
    }
}
