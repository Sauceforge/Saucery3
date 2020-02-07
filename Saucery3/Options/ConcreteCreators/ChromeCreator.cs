using Saucery3.Options.Base;
using Saucery3.Options.ConcreteProducts;
using Saucery3.OnDemand;

namespace Saucery3.Options.ConcreteCreators {
    internal class ChromeCreator : Creator {
        public override BaseOptions Create(SaucePlatform platform, string testName) {
            return new ChromeBrowserOptions(platform, testName);
        }
    }
}
/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */