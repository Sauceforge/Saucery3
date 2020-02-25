using OpenQA.Selenium;
using Saucery3.OnDemand;
using Saucery3.Options.ConcreteCreators;
using Saucery3.Util;
using System;

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
                    if (!platform.BrowserVersion.FirefoxVersionIsSupported())
                    {
                        Console.WriteLine(SauceryConstants.NOT_SUPPORTED_MESSAGE);
                        return null;
                    }
                    return new FirefoxCreator().Create(platform, testName).GetOpts();
                case "internet explorer":
                    if (!platform.BrowserVersion.IEVersionIsSupported())
                    {
                        Console.WriteLine(SauceryConstants.NOT_SUPPORTED_MESSAGE);
                        return null;
                    }
                    return new IECreator().Create(platform, testName).GetOpts();
                case "microsoftedge":
                    return new EdgeCreator().Create(platform, testName).GetOpts();
                case "chrome":
                    if (!platform.BrowserVersion.ChromeVersionIsSupported())
                    {
                        Console.WriteLine(SauceryConstants.NOT_SUPPORTED_MESSAGE);
                        return null;
                    }
                    return new ChromeCreator().Create(platform, testName).GetOpts();
                case "safari":
                    if (!platform.BrowserVersion.SafariVersionIsSupported())
                    {
                        Console.WriteLine(SauceryConstants.NOT_SUPPORTED_MESSAGE);
                        return null;
                    }
                    return new SafariCreator().Create(platform, testName).GetOpts();
                default:
                    if (!platform.BrowserVersion.ChromeVersionIsSupported())
                    {
                        Console.WriteLine(SauceryConstants.NOT_SUPPORTED_MESSAGE);
                        return null;
                    }
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