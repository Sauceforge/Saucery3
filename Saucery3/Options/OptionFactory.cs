using OpenQA.Selenium;
using Saucery3.OnDemand;
using Saucery3.Options.ConcreteCreators;

namespace Saucery3.Options
{
    public class OptionFactory
    {
        private SaucePlatform Platform { get; set; }

        public OptionFactory(SaucePlatform platform)
        {
            Platform = platform;
        }

        public DriverOptions CreateOptions(string testName) {
            if (Platform.IsADesktopPlatform()) {
                return GetDesktopOptions(Platform, testName);
            }
            //Mobile Platform
            return Platform.IsAnAppleDevice()
                    ? new AppiumIOSCreator().Create(Platform, testName).GetOpts()
                    : new AppiumAndroidCreator().Create(Platform, testName).GetOpts();
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

        public bool IsSupportedPlatform()
        {
            switch (Platform.Browser.ToLower())
            {
                case "firefox":
                    return Platform.FirefoxVersionIsSupported();
                case "internet explorer":
                    return Platform.IEVersionIsSupported();
                case "microsoftedge":
                    return true;
                case "chrome":
                    return Platform.ChromeVersionIsSupported();
                case "safari":
                    return Platform.SafariVersionIsSupported();
                default:
                    return false;
            }
        }
    }
}
/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */