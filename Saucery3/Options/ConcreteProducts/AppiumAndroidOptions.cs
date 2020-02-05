using System;
using OpenQA.Selenium.Appium;
using Saucery3.Options.Base;
using Saucery3.OnDemand;
using Saucery3.Util;
using OpenQA.Selenium.Appium.Enums;

namespace Saucery3.Options.ConcreteProducts
{
    internal class AppiumAndroidOptions : BaseOptions {
        public AppiumAndroidOptions(SaucePlatform platform, string testName)
            : base(testName)
        {
            var nativeApp = Enviro.SauceNativeApp;
            var useChromeOnAndroid = Enviro.SauceUseChromeOnAndroid;
            Console.WriteLine(SauceryConstants.SETTING_UP, testName, SauceryConstants.ANDROID_ON_APPIUM);
            Opts = new AppiumOptions();

            //See https://github.com/appium/appium-dotnet-driver/wiki/Android-Sample
            //AndroidDriver<AppiumWebElement> ad = new AndroidDriver<AppiumWebElement>(Caps);

            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_APPIUM_VERSION_CAPABILITY, Enviro.RecommendedAppiumVersion);
            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_DEVICE_NAME_CAPABILITY, platform.LongName);
            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_DEVICE_ORIENTATION_CAPABILITY, platform.DeviceOrientation);
            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_BROWSER_NAME_CAPABILITY, GetBrowser(nativeApp, useChromeOnAndroid));
            //Opts.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, platform.LongVersion);
            //Opts.AddAdditionalCapability(MobileCapabilityType.PlatformName, SauceryConstants.ANDROID);
            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_PLATFORM_VERSION_CAPABILITY, platform.LongVersion);
            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_PLATFORM_NAME_CAPABILITY, SauceryConstants.ANDROID);
            
            AddSauceLabsOptions(nativeApp);
        }
    }
}
/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */