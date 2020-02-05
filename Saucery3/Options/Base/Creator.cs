using Saucery3.OnDemand;

namespace Saucery3.Options.Base {
    internal abstract class Creator {
        public abstract BaseOptions Create(SaucePlatform platform, string testName);
    }
}
/*
 * Copyright Andrew Gray, SauceForge
 * Date: 5th February 2020
 * 
 */