using System;
using System.IO;
using Xamarin.UITest;

namespace XamarinNativeExamples.UITest
{
    public static class AppManager
    {
        private const string RelativeApkPath = @"..\..\..\XamarinNativeExamples.Droid\bin\Debug\com.astromobilesolutions.xamarinnativeexamples.droid.apk";
        private const string AppPath = "../../..";
        private const string IpaBundleId = "com.astromobilesolutions.xamarinnativeexamples.ios";

        static IApp app;
        public static IApp App
        {
            get
            {
                if (app == null)
                    throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                return app;
            }
        }

        static Platform? platform;
        public static Platform Platform
        {
            get
            {
                if (platform == null)
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                return platform.Value;
            }

            set
            {
                platform = value;
            }
        }

        public static void StartApp()
        {
            if (Platform == Platform.Android)
            {
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                var path = Path.GetFullPath(Path.Combine(baseDirectory, RelativeApkPath));

                app = ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .ApkFile(path)
                    .StartApp();
            }

            if (Platform == Platform.iOS)
            {
                app = ConfigureApp
                    .iOS
                    .EnableLocalScreenshots()
                    .AppBundle(AppPath)
                    .StartApp();
            }
        }
    }
}
