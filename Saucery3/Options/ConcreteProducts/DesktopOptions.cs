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

            Opts = platform.Browser.ToLower().Equals("chrome")
                    ? new ChromeOptions()
                    : platform.Browser.ToLower().Equals("firefox")
                        ? new FirefoxOptions()
                        : platform.Browser.ToLower().Equals("safari")
                            ? new SafariOptions()
                            : platform.Browser.ToLower().Equals("internetexplorer")
                                ? new InternetExplorerOptions()
                                : platform.Browser.ToLower().Equals("msedge")
                                    ? new EdgeOptions()
                                    : (DriverOptions) new ChromeOptions();

            //if (platform.Browser.ToLower().Equals("chrome"))
            //{
            //    Opts.UseSpecCompliantProtocol = true;
            //}
            Opts.PlatformName = platform.Os;
            Opts.BrowserVersion = platform.BrowserVersion;
            Opts.AddAdditionalCapability("sauce:options", SauceOptions);
        }
    }
}

/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */