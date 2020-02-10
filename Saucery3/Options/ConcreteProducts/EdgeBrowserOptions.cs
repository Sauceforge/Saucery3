using System;
using Saucery3.Options.Base;
using Saucery3.OnDemand;
using Saucery3.Util;
using OpenQA.Selenium.Edge;

namespace Saucery3.Options.ConcreteProducts {
    internal class EdgeBrowserOptions : BaseOptions {
        public EdgeBrowserOptions(SaucePlatform platform, string testName) : base(testName)
        {
            Console.WriteLine(SauceryConstants.SETTING_UP, testName, SauceryConstants.DESKTOP_ON_WEBDRIVER);

            DebugMessages.PrintDesktopOptionValues(platform);
            
            Console.WriteLine("Creating Edge Options");
            var o = new EdgeOptions
            {
                PlatformName = platform.Os,
                BrowserVersion = platform.BrowserVersion
            };
            o.AddAdditionalCapability(SauceryConstants.SAUCE_OPTIONS_CAPABILITY, SauceOptions);
            Opts = o;
        }
    }
}

/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */