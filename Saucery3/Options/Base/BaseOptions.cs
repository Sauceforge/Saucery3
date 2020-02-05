using OpenQA.Selenium;
using Saucery3.Util;
using System.Collections.Generic;

namespace Saucery3.Options.Base
{
    internal abstract class BaseOptions {
        protected DriverOptions Opts = null;
        protected Dictionary<string, object> SauceOptions = null;
        private readonly string _testName;

        protected BaseOptions(string testName) {
            _testName = testName;
            SauceOptions = new Dictionary<string, object>();
            AddSauceLabsOptions();
        }

        protected void AddSauceLabsOptions() {
            SauceOptions.Add(SauceryConstants.SAUCE_USERNAME_CAPABILITY, Enviro.SauceUserName);
            SauceOptions.Add(SauceryConstants.SAUCE_ACCESSKEY_CAPABILITY, Enviro.SauceApiKey);
            //This sets the Session column
            SauceOptions.Add(SauceryConstants.SAUCE_SESSIONNAME_CAPABILITY, _testName);
            //This sets the Build column
            SauceOptions.Add(SauceryConstants.SAUCE_BUILDNAME_CAPABILITY, Enviro.BuildNumber);
            //Improve performance on SauceLabs
            SauceOptions.Add(SauceryConstants.SAUCE_VUOP_CAPABILITY, false);
            //SauceOptions.Add(Constants.VISIBILITY_KEY, Constants.VISIBILITY_TEAM);
        }

        protected void AddSauceLabsOptions(string nativeApp) {
            if (nativeApp != null) {
                SauceOptions.Add(SauceryConstants.SAUCE_NATIVE_APP_CAPABILITY, nativeApp);
            }
        }

        public DriverOptions GetOpts() {
            return Opts;
        }

        protected static string GetBrowser(string nativeApp, bool useChromeOnAndroid) {
            return nativeApp != null
                ? ""
                : useChromeOnAndroid
                    ? SauceryConstants.CHROME_BROWSER
                    : SauceryConstants.DEFAULT_ANDROID_BROWSER;
        }

        protected static string GetBrowser(string nativeApp) {
            return nativeApp != null ? "" : SauceryConstants.SAFARI_BROWSER;
        }
    }
}
/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */