using NUnit.Framework;
using OpenQA.Selenium;

namespace Lab11_12
{
    [TestFixture]
    public class Setup
    {
        protected IWebDriver? driver;

        [SetUp]
        public void InitDriver()
        {
            driver = DriverInstance.GetDriver(Browser.FIREFOX);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver?.Quit();
            driver?.Dispose();
            DriverInstance.CloseBrowser();
        }
    }
}