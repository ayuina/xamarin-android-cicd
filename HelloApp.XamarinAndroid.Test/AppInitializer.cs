using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace HelloApp.XamarinAndroid.Test
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.ApkFile("com.companyname.HelloApp.XamarinAndroid.apk").StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}