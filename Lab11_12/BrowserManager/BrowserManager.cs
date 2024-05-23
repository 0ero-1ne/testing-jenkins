using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Lab11_12
{
    public static class BrowserManager
    {
        public static IWebDriver GetBrowser(Browser browser)
        {
            IWebDriver driver;

            driver = browser switch
            {
                Browser.EDGE => EdgeBrowser(),
                Browser.FIREFOX => FirefoxBrowser(),
                _ => FirefoxBrowser(),
            };

            return driver;
        }

        private static FirefoxDriver FirefoxBrowser()
        {
            return new FirefoxDriver();
        }

        private static EdgeDriver EdgeBrowser()
        {
            return new EdgeDriver();
        }
    }
}