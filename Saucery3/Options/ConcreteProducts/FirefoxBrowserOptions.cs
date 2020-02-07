﻿using System;
using Saucery3.Options.Base;
using Saucery3.OnDemand;
using Saucery3.Util;
using OpenQA.Selenium.Firefox;

namespace Saucery3.Options.ConcreteProducts {
    internal class FirefoxBrowserOptions : BaseOptions {
        public FirefoxBrowserOptions(SaucePlatform platform, string testName) : base(testName)
        {
            Console.WriteLine(SauceryConstants.SETTING_UP, testName, SauceryConstants.DESKTOP_ON_WEBDRIVER);

            Console.WriteLine("platform.Browser: {0}", platform.Browser);
            Console.WriteLine("platform.Os: {0}", platform.Os);
            Console.WriteLine("platform.BrowserVersion: {0}", platform.BrowserVersion);

            Console.WriteLine("Creating Firefox Options");
            var o = new FirefoxOptions
            {
                PlatformName = platform.Os,
                BrowserVersion = platform.BrowserVersion
            };
            o.AddAdditionalCapability(SauceryConstants.SAUCE_OPTIONS_CAPABILITY, SauceOptions, true);
            Opts = o;
        }
    }
}

/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */