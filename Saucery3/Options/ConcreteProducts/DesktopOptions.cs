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

            Console.WriteLine("platform.Browser: {0}", platform.Browser);
            Console.WriteLine("platform.Os: {0}", platform.Os);
            Console.WriteLine("platform.BrowserVersion: {0}", platform.BrowserVersion);
            //This section needs to be another factory.

            if (platform.Browser.ToLower().Contains("chrome"))
            {
                Opts = CreateChromeOptions(platform);
            }
            else
            {
                if (platform.Browser.ToLower().Contains("firefox"))
                {
                    Opts = CreateFirefoxOptions(platform);
                }
                else
                {
                    if (platform.Browser.ToLower().Contains("safari"))
                    {
                        Opts = CreateSafariOptions(platform);
                    }
                    else
                    {
                        if (platform.Browser.ToLower().Contains("internet explorer"))
                        {
                            Opts = CreateInternetExplorerOptions(platform);
                        }
                        else
                        {
                            if (platform.Browser.ToLower().Contains("MicrosoftEdge"))
                            {
                                Opts = CreateEdgeOptions(platform);
                            }
                            else
                            {
                                Opts = CreateChromeOptions(platform);
                            }
                        }
                    }
                }
            }
        }

        private ChromeOptions CreateChromeOptions(SaucePlatform platform)
        {
            Console.WriteLine("Creating Chrome Options");
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
            Console.WriteLine("Creating Firefox Options");
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
            Console.WriteLine("Creating Safari Options");
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
            Console.WriteLine("Creating IE Options");
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
            Console.WriteLine("Creating Edge Options");
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