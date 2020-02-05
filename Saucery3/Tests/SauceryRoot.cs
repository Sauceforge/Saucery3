using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Saucery3.OnDemand;
using Saucery3.Options;
using Saucery3.RestAPI.FlowControl;
using Saucery3.RestAPI.RecommendedAppiumVersion;
using Saucery3.RestAPI.TestStatus;
using Saucery3.Util;
using System.Collections.Generic;

namespace Saucery3.Tests
{
    [TestFixture]
    //[Parallelizable(ParallelScope.Fixtures)]
    public abstract class SauceryRoot {
        protected string TestName;
        protected readonly SaucePlatform Platform;
        protected static SauceLabsStatusNotifier SauceLabsStatusNotifier;
        internal static SauceLabsFlowController SauceLabsFlowController;
        protected static SauceLabsAppiumRecommender SauceLabsAppiumRecommender;


        protected SauceryRoot(SaucePlatform platform) {
            //Console.WriteLine(@"In SauceryRoot constructor");
            Platform = platform;
        }

        static SauceryRoot() {
            OnceOnlyMessages.TestingOn(JsonConvert.DeserializeObject<List<SaucePlatform>>(Enviro.SauceOnDemandBrowsers));
            OnceOnlyMessages.OnDemand();
            SauceLabsStatusNotifier = new SauceLabsStatusNotifier();
            SauceLabsFlowController = new SauceLabsFlowController();
        }

        [SetUp]
        public void Setup() {
            //Console.WriteLine("In Setup");
            TestName = Platform.GetTestName(TestContext.CurrentContext.Test.Name);

            //DebugMessages.PrintPlatformDetails(platform);
            // set up the desired capabilities
            var opts = OptionFactory.CreateOptions(Platform, TestName);
            InitialiseDriver(opts, 30);
        }

        public abstract void InitialiseDriver(DriverOptions opts, int waitSecs);
        public abstract void InitialiseDriver(ICapabilities driver, int waitSecs);
    }
}
/*
 * Copyright Andrew Gray, SauceForge
 * Date: 12th July 2014
 * 
 */