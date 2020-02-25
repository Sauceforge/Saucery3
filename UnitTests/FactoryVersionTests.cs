using NUnit.Framework;
using Saucery3.OnDemand;
using Saucery3.Options;
using Shouldly;
using System.Collections;

namespace UnitTests
{
    [TestFixture]
    public class FactoryVersionTests
    {
        [Test, TestCaseSource(typeof(DataClass), "SupportedTestCases")]
        public void IsSupportedPlatformTest(SaucePlatform saucePlatform)
        {
            var factory = new OptionFactory(saucePlatform);
            var result = factory.IsSupportedPlatform();
            result.ShouldBeTrue();
        }

        [Test, TestCaseSource(typeof(DataClass), "NotSupportedTestCases")]
        public void IsNotSupportedPlatformTest(SaucePlatform saucePlatform)
        {
            var factory = new OptionFactory(saucePlatform);
            var result = factory.IsSupportedPlatform();
            result.ShouldBeFalse();
        }

        [Test, TestCaseSource(typeof(DataClass), "SupportedTestCases")]
        public void DesktopOptionTest(SaucePlatform saucePlatform)
        {
            var factory = new OptionFactory(saucePlatform);
            var opts = factory.CreateOptions("DesktopOptionTest");
            opts.ShouldNotBeNull();
        }
    }
    public class DataClass
    {
        public static IEnumerable SupportedTestCases
        {
            get
            {
                yield return new TestCaseData(new SaucePlatform("", "", "chrome", "62", "", "", "", "", ""));
                yield return new TestCaseData(new SaucePlatform("", "", "chrome", "61", "", "", "", "", ""));
                yield return new TestCaseData(new SaucePlatform("", "", "firefox", "54", "", "", "", "", ""));
                yield return new TestCaseData(new SaucePlatform("", "", "firefox", "53", "", "", "", "", ""));
                yield return new TestCaseData(new SaucePlatform("", "", "safari", "12", "", "", "", "", ""));
                yield return new TestCaseData(new SaucePlatform("", "", "safari", "11", "", "", "", "", ""));
                yield return new TestCaseData(new SaucePlatform("", "", "internet explorer", "11", "", "", "", "", ""));
                yield return new TestCaseData(new SaucePlatform("", "", "microsoftedge", "80", "", "", "", "", ""));
            }
        }

        public static IEnumerable NotSupportedTestCases
        {
            get
            {
                yield return new TestCaseData(new SaucePlatform("", "", "chrome", "60", "", "", "", "", ""));
                yield return new TestCaseData(new SaucePlatform("", "", "firefox", "52", "", "", "", "", ""));
                yield return new TestCaseData(new SaucePlatform("", "", "safari", "10", "", "", "", "", ""));
                yield return new TestCaseData(new SaucePlatform("", "", "internet explorer", "10", "", "", "", "", ""));
            }
        }
    }
}
