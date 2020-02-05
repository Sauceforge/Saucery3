using OpenQA.Selenium;
using Saucery3.OnDemand;
using Saucery3.Options.ConcreteCreators;

namespace Saucery3.Options
{
    internal class OptionFactory {
        public static DriverOptions CreateOptions(SaucePlatform platform, string testName) {
            if (platform.IsADesktopPlatform()) {
                return new DesktopCreator().Create(platform, testName).GetOpts();
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
    }
}
/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */