using OpenQA.Selenium;
using Saucery3.OnDemand;
using Saucery3.Options.ConcreteCreators;

namespace Saucery3.Options
{
    internal class OptionFactory {
        public static DriverOptions CreateOptions(SaucePlatform platform, string testName) {
            if (platform.IsADesktopPlatform()) {
                return GetDesktopOptions(platform, testName);
            }
            //Mobile Platform
            return platform.IsAnAppleDevice()
                    ? new AppiumIOSCreator().Create(platform, testName).GetOpts()
                    : new AppiumAndroidCreator().Create(platform, testName).GetOpts();
            //return platform.CanUseAppium()
            //    //Mobile Platform
            //    ? platform.IsAnAppleDevice()
            //        ? new AppiumIOSCreator().Create(platform, testName).GetOpts()
            //        : new AppiumAndroidCreator().Create(platform, testName).GetOpts()
            //    //Devolve to WebDriver    
            //    : platform.IsAnAppleDevice()
            //        ? new WebDriverIOSCreator().Create(platform, testName).GetCaps()
            //        : new WebDriverAndroidCreator().Create(platform, testName).GetCaps();
        }

        private static DriverOptions GetDesktopOptions(SaucePlatform platform, string testName)
        {
            switch (platform.Browser.ToLower())
            {
                case "firefox":
                    return new FirefoxCreator().Create(platform, testName).GetOpts();
                case "internet explorer":
                    return new IECreator().Create(platform, testName).GetOpts();
                case "microsoftedge":
                    return new EdgeCreator().Create(platform, testName).GetOpts();
                case "chrome":
                    return new ChromeCreator().Create(platform, testName).GetOpts();
                case "safari":
                    return new SafariCreator().Create(platform, testName).GetOpts();
                default:
                    return new ChromeCreator().Create(platform, testName).GetOpts();
            }
        }
    }
}
/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */