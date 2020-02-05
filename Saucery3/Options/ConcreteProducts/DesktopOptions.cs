using System;
using Saucery3.Options.Base;
using Saucery3.OnDemand;
using Saucery3.Util;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;

namespace Saucery3.Options.ConcreteProducts {
    internal class DesktopOptions : BaseOptions {
        public DesktopOptions(SaucePlatform platform, string testName)
            : base(testName)
        {
            Console.WriteLine(SauceryConstants.SETTING_UP, testName, SauceryConstants.DESKTOP_ON_WEBDRIVER);

            //This section needs to be another factory.
            Opts = platform.Browser.ToLower().Equals("chrome")
                    ? CreateChromeOptions(platform)
                    : platform.Browser.ToLower().Equals("firefox")
                        ? CreateFirefoxOptions(platform)
                        : platform.Browser.ToLower().Equals("safari")
                            ? CreateSafariOptions(platform)
                            : platform.Browser.ToLower().Equals("internetexplorer")
                                ? CreateInternetExplorerOptions(platform)
                                : platform.Browser.ToLower().Equals("msedge")
                                    ? CreateEdgeOptions(platform)
                                    : (DriverOptions) CreateChromeOptions(platform);
        }

        private ChromeOptions CreateChromeOptions(SaucePlatform platform)
        {
            var o = new ChromeOptions() 
            {
                PlatformName = platform.Os,
                BrowserVersion = platform.BrowserVersion,
                UseSpecCompliantProtocol = true 
            };
            o.AddAdditionalCapability("sauce:options", SauceOptions, true);
            return o;
        }

        private FirefoxOptions CreateFirefoxOptions(SaucePlatform platform)
        {
            var o = new FirefoxOptions
            {
                PlatformName = platform.Os,
                BrowserVersion = platform.BrowserVersion
            };
            o.AddAdditionalCapability("sauce:options", SauceOptions, true);
            return o;
        }

        private SafariOptions CreateSafariOptions(SaucePlatform platform)
        {
            var o = new SafariOptions
            {
                PlatformName = platform.Os,
                BrowserVersion = platform.BrowserVersion
            };
            o.AddAdditionalCapability("sauce:options", SauceOptions);
            return o;
        }

        private InternetExplorerOptions CreateInternetExplorerOptions(SaucePlatform platform)
        {
            var o = new InternetExplorerOptions
            {
                PlatformName = platform.Os,
                BrowserVersion = platform.BrowserVersion
            };
            o.AddAdditionalCapability("sauce:options", SauceOptions, true);
            return o;
        }

        private EdgeOptions CreateEdgeOptions(SaucePlatform platform)
        {
            var o = new EdgeOptions
            {
                PlatformName = platform.Os,
                BrowserVersion = platform.BrowserVersion
            };
            o.AddAdditionalCapability("sauce:options", SauceOptions);
            return o;
        }
    }
}

/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */