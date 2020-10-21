using Foundation;

namespace XamarinNativeExamples.iOS.Helpers
{
    public static class StringHelper
    {
        public static string StringResource(string key)
        {
            return NSBundle.MainBundle.GetLocalizedString(key);
        }
    }
}