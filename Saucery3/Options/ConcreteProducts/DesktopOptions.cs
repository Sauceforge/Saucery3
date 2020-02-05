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
                    ? CreateChromeOptions()
                    : platform.Browser.ToLower().Equals("firefox")
                        ? CreateFirefoxOptions()
                        : platform.Browser.ToLower().Equals("safari")
                            ? CreateSafariOptions()
                            : platform.Browser.ToLower().Equals("internetexplorer")
                                ? CreateInternetExplorerOptions()
                                : platform.Browser.ToLower().Equals("msedge")
                                    ? CreateEdgeOptions()
                                    : (DriverOptions) CreateChromeOptions();
            
            Opts.PlatformName = platform.Os;
            Opts.BrowserVersion = platform.BrowserVersion;

            //Opts.AddAdditionalCapability(SauceryConstants.SAUCE_USERNAME_CAPABILITY, Enviro.SauceUserName);
            //Opts.AddAdditionalCapability(SauceryConstants.SAUCE_ACCESSKEY_CAPABILITY, Enviro.SauceApiKey);
            
            //Opts.AddAdditionalCapability("sauce:options", SauceOptions);
        }

        private ChromeOptions CreateChromeOptions()
        {
            var o = new ChromeOptions() { UseSpecCompliantProtocol = true };
            o.AddAdditionalCapability("sauce:options", SauceOptions, true);
            return o;
        }

        private FirefoxOptions CreateFirefoxOptions()
        {
            var o = new FirefoxOptions();
            o.AddAdditionalCapability("sauce:options", SauceOptions, true);
            return o;
        }

        private SafariOptions CreateSafariOptions()
        {
            var o = new SafariOptions();
            o.AddAdditionalCapability("sauce:options", SauceOptions);
            return o;
        }

        private InternetExplorerOptions CreateInternetExplorerOptions()
        {
            var o = new InternetExplorerOptions();
            o.AddAdditionalCapability("sauce:options", SauceOptions, true);
            return o;
        }

        private EdgeOptions CreateEdgeOptions()
        {
            var o = new EdgeOptions();
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