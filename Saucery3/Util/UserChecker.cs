﻿namespace Saucery3.Util {
    internal static class UserChecker {
        internal static bool ItIsMe() {
            return Enviro.SauceUserName.ToLower().Equals(SauceryConstants.MY_USERNAME_LOWER);
        }
    }
}
/*
 * Copyright Andrew Gray, SauceForge
 * Date: 29th July 2014
 * 
 */