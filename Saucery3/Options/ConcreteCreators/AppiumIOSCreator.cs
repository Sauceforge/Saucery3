using Saucery3.Options.ConcreteProducts;
using Saucery3.OnDemand;
using Saucery3.Options.Base;

namespace Saucery3.Options.ConcreteCreators
{
    internal class AppiumIOSCreator : Creator {
        public override BaseOptions Create(SaucePlatform platform, string testName)
        {
            return new AppiumIOSOptions(platform, testName);
        }
    }
}
/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 202
 * 
 */