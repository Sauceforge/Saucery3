using System;
using Saucery3.Options.Base;
using Saucery3.OnDemand;
using Saucery3.Util;
using OpenQA.Selenium.Appium;

namespace Saucery3.Options.ConcreteProducts {
    internal class AppiumIOSOptions : BaseOptions {
        public AppiumIOSOptions(SaucePlatform platform, string testName) : base(testName) {
            Console.WriteLine(SauceryConstants.SETTING_UP, testName, SauceryConstants.IOS_ON_APPIUM);
            AddSauceLabsOptions(Enviro.SauceNativeApp);

            DebugMessages.PrintiOSOptionValues(platform);

            Console.WriteLine("Creating iOS Options");
            Opts = new AppiumOptions();
            //Opts.AddAdditionalCapability(SauceryConstants.SAUCE_APPIUM_VERSION_CAPABILITY, Enviro.RecommendedAppiumVersion);
            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_DEVICE_NAME_CAPABILITY, platform.Device);
            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_DEVICE_ORIENTATION_CAPABILITY, platform.DeviceOrientation);
            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_PLATFORM_VERSION_CAPABILITY, platform.BrowserVersion);
            //Opts.AddAdditionalCapability(SauceryConstants.SAUCE_PLATFORM_NAME_CAPABILITY, SauceryConstants.IOS_PLATFORM);
            //Opts.AddAdditionalCapability(SauceryConstants.SAUCE_BROWSER_NAME_CAPABILITY, SauceryConstants.SAFARI_BROWSER);

            //Opts.AddAdditionalCapability(SauceryConstants.SAUCE_DEVICE_CAPABILITY, platform.Device);
            //Opts.AddAdditionalCapability(SauceryConstants.SAUCE_DEVICE_CAPABILITY, platform.IsAnIPhone() ? SauceryConstants.IPHONE_DEVICE : SauceryConstants.IPAD_DEVICE);
            //Opts.AddAdditionalCapability(SauceryConstants.SAUCE_DEVICE_CAPABILITY, platform.IsAnIPhone() ? SauceryConstants.IPHONE_SIMULATOR : SauceryConstants.IPAD_SIMULATOR);

            Opts.AddAdditionalCapability(SauceryConstants.SAUCE_OPTIONS_CAPABILITY, SauceOptions);
        }
    }
}
/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */