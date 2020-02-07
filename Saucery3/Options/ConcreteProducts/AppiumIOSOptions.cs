using System;
using Saucery3.Options.Base;
using Saucery3.OnDemand;
using Saucery3.Util;
using OpenQA.Selenium.Appium;

namespace Saucery3.Options.ConcreteProducts {
    internal class AppiumIOSOptions : BaseOptions {
        public AppiumIOSOptions(SaucePlatform platform, string testName) : base(testName) {
            var nativeApp = Enviro.SauceNativeApp;
            Console.WriteLine(SauceryConstants.SETTING_UP, testName, SauceryConstants.IOS_ON_APPIUM);
            Opts = new AppiumOptions();

            //See https://github.com/appium/appium-dotnet-driver/wiki/Android-Sample
            //IOSDriver<AppiumWebElement> iosd = new IOSDriver<AppiumWebElement>(Caps);

            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_APPIUM_VERSION_CAPABILITY, Enviro.RecommendedAppiumVersion);
            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_DEVICE_NAME_CAPABILITY, platform.IsAnIPhone() ? SauceryConstants.IPHONE_SIMULATOR : SauceryConstants.IPAD_SIMULATOR);
            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_DEVICE_ORIENTATION_CAPABILITY, platform.DeviceOrientation);
            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_PLATFORM_VERSION_CAPABILITY, platform.BrowserVersion);
            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_PLATFORM_NAME_CAPABILITY, SauceryConstants.IOS_PLATFORM);
            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_BROWSER_NAME_CAPABILITY, GetBrowser(nativeApp));
            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_DEVICE_CAPABILITY, platform.IsAnIPhone() ? SauceryConstants.IPHONE_DEVICE : SauceryConstants.IPAD_DEVICE);

            Console.WriteLine("{0}:{1}\n{2}:{3}\n{4}:{5}\n{6}:{7}\n{8}:{9}\n{10}:{11}\n{12}:{13}",
                              SauceryConstants.SAUCE_APPIUM_VERSION_CAPABILITY, Enviro.RecommendedAppiumVersion,
                              SauceryConstants.SAUCE_DEVICE_NAME_CAPABILITY, platform.IsAnIPhone() ? SauceryConstants.IPHONE_SIMULATOR : SauceryConstants.IPAD_SIMULATOR,
                              SauceryConstants.SAUCE_DEVICE_ORIENTATION_CAPABILITY, platform.DeviceOrientation,
                              SauceryConstants.SAUCE_PLATFORM_VERSION_CAPABILITY, platform.BrowserVersion,
                              SauceryConstants.SAUCE_PLATFORM_NAME_CAPABILITY, SauceryConstants.IOS_PLATFORM,
                              SauceryConstants.SAUCE_BROWSER_NAME_CAPABILITY, GetBrowser(nativeApp),
                              SauceryConstants.SAUCE_DEVICE_CAPABILITY, platform.IsAnIPhone() ? SauceryConstants.IPHONE_DEVICE : SauceryConstants.IPAD_DEVICE);

            AddSauceLabsOptions(nativeApp);
        }
    }
}
/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */