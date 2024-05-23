using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Lab11_12
{
    public class DriverInstance
    {
        private static IWebDriver? driver;

        public static IWebDriver GetDriver(Browser browser)
        {
            if (driver == null) {
                driver = BrowserManager.GetBrowser(browser);
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver?.Dispose();
            driver = null;
        }
    }
}