using System;
using Saucery3.DataSources;
using Saucery3.OnDemand;
using Saucery3.Options;

namespace Saucery3.Util {
    public class DebugMessages {
        public static void PrintPlatformDetails(PlatformTestData platform) {
            if (UserChecker.ItIsMe())
            {
                Console.WriteLine("DEBUG MESSAGE START");
                Console.WriteLine(@"SELENIUM_OS=" + platform.Os);
                Console.WriteLine(@"SELENIUM_BROWSER=" + platform.BrowserName);
                Console.WriteLine(@"SELENIUM_VERSION=" + platform.BrowserVersion);
                Console.WriteLine(@"SELENIUM_LONG_VERSION=" + platform.LongVersion);
                Console.WriteLine(@"SELENIUM_DEVICE_TYPE=" + platform.DeviceType);
                Console.WriteLine(@"SELENIUM_DEVICE=" + platform.Device);
                Console.WriteLine("DEBUG MESSAGE END");
            }
        }

        public static void ExtractJsonSegment(string json, int startIndex, int endIndex) {
            if (UserChecker.ItIsMe())
            {
                Console.WriteLine("DEBUG MESSAGE: ExtractJsonSegment params {0} {1} {2}", json, startIndex, endIndex);
                Console.Out.Flush();
            }
        }

        public static void PrintDesktopOptionValues(SaucePlatform platform)
        {
            if (UserChecker.ItIsMe())
            {
                Console.WriteLine("platform.Browser: {0}", platform.Browser);
                Console.WriteLine("platform.Os: {0}", platform.Os);
                Console.WriteLine("platform.BrowserVersion: {0}", platform.BrowserVersion);
            }
        }

        public static void PrintiOSOptionValues(SaucePlatform platform)
        {
            Console.WriteLine("{0}:{1}\n{2}:{3}\n{4}:{5}\n{6}:{7}\n{8}:{9}\n{10}:{11}",
                              SauceryConstants.SAUCE_DEVICE_NAME_CAPABILITY, platform.Device,
                              SauceryConstants.SAUCE_DEVICE_ORIENTATION_CAPABILITY, platform.DeviceOrientation,
                              SauceryConstants.SAUCE_PLATFORM_VERSION_CAPABILITY, platform.BrowserVersion,
                              SauceryConstants.SAUCE_PLATFORM_NAME_CAPABILITY, SauceryConstants.IOS_PLATFORM,
                              SauceryConstants.SAUCE_BROWSER_NAME_CAPABILITY, SauceryConstants.SAFARI_BROWSER,
                              //SauceryConstants.SAUCE_DEVICE_CAPABILITY, platform.Device
                              //SauceryConstants.SAUCE_DEVICE_CAPABILITY, platform.IsAnIPhone() ? SauceryConstants.IPHONE_DEVICE : SauceryConstants.IPAD_DEVICE
                              SauceryConstants.SAUCE_DEVICE_CAPABILITY, platform.IsAnIPhone() ? SauceryConstants.IPHONE_SIMULATOR : SauceryConstants.IPAD_SIMULATOR
                              );
        }

        public static void PrintAndroidOptionValues(SaucePlatform platform, string sanitisedLongVersion)
        {
            Console.WriteLine("{0}:{1}\n{2}:{3}\n{4}:{5}\n{6}:{7}\n{8}:{9}",
                              SauceryConstants.SAUCE_DEVICE_NAME_CAPABILITY, platform.LongName,
                              SauceryConstants.SAUCE_DEVICE_ORIENTATION_CAPABILITY, platform.DeviceOrientation,
                              SauceryConstants.SAUCE_BROWSER_NAME_CAPABILITY, SauceryConstants.CHROME_BROWSER,
                              SauceryConstants.SAUCE_PLATFORM_VERSION_CAPABILITY, sanitisedLongVersion,
                              SauceryConstants.SAUCE_PLATFORM_NAME_CAPABILITY, SauceryConstants.ANDROID);
        }
    }
}

/*
 * Copyright Andrew Gray, SauceForge
 * Date: 25th August 2014
 * 
 */