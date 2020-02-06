using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using Saucery3.Capabilities.Base;
using Saucery3.OnDemand;
using Saucery3.Util;

namespace Saucery3.Capabilities.ConcreteProducts {
    internal class AppiumAndroidCapabilities : BaseCapabilities {
        public AppiumAndroidCapabilities(SaucePlatform platform, string testName)
            : base(testName)
        {
            var nativeApp = Enviro.SauceNativeApp;
            var useChromeOnAndroid = Enviro.SauceUseChromeOnAndroid;
            Console.WriteLine(SauceryConstants.SETTING_UP, testName, SauceryConstants.ANDROID_ON_APPIUM);
            //Caps = DesiredCapabilities.Android();
            Caps = new DesiredCapabilities();

            //See https://github.com/appium/appium-dotnet-driver/wiki/Android-Sample
            //AndroidDriver<AppiumWebElement> ad = new AndroidDriver<AppiumWebElement>(Caps);

            //Caps.SetCapability(SauceryConstants.SAUCE_APPIUM_VERSION_CAPABILITY, Enviro.RecommendedAppiumVersion);
            Caps.SetCapability(SauceryConstants.SAUCE_DEVICE_NAME_CAPABILITY, platform.LongName);
            Caps.SetCapability(SauceryConstants.SAUCE_DEVICE_ORIENTATION_CAPABILITY, platform.DeviceOrientation);
            Caps.SetCapability(SauceryConstants.SAUCE_BROWSER_NAME_CAPABILITY, GetBrowser(nativeApp, useChromeOnAndroid));
            Caps.SetCapability(SauceryConstants.SAUCE_PLATFORM_VERSION_CAPABILITY, platform.LongVersion);
            Caps.SetCapability(SauceryConstants.SAUCE_PLATFORM_NAME_CAPABILITY, SauceryConstants.ANDROID);

            Console.WriteLine("{0}:{1} {2}:{3} {4}:{5} {6}:{7} {8}:{9}",
                              SauceryConstants.SAUCE_DEVICE_NAME_CAPABILITY, platform.LongName,
                              SauceryConstants.SAUCE_DEVICE_ORIENTATION_CAPABILITY, platform.DeviceOrientation,
                              SauceryConstants.SAUCE_BROWSER_NAME_CAPABILITY, GetBrowser(nativeApp, useChromeOnAndroid),
                              SauceryConstants.SAUCE_PLATFORM_VERSION_CAPABILITY, platform.LongVersion,
                              SauceryConstants.SAUCE_PLATFORM_NAME_CAPABILITY, SauceryConstants.ANDROID);

            AddSauceLabsCapabilities(nativeApp);
        }
    }
}
/*
 * Copyright Andrew Gray, Full Circle Solutions
 * Date: 10th September 2014
 * 
 */