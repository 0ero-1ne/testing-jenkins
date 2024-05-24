using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Lab11_12
{
    class LinkinParkStoreHomePage
    {
        private IWebDriver webDriver;
        private WebDriverWait webDriverWait;
        private readonly string HomePageUrl = UrlUtils.HOME_PAGE;

        public LinkinParkStoreHomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            webDriverWait = new(webDriver, TimeSpan.FromSeconds(10));
        }

        public LinkinParkStoreHomePage NavigateToHomePage()
        {
            webDriver.Navigate().GoToUrl(HomePageUrl);
            webDriverWait.Until(driver => driver.Url.Contains(HomePageUrl));
            return this;
        }

        public LinkinParkStoreHomePage SetStoreLocalization(Localization localization)
        {
            var localizationButtonParrentElement = webDriver.FindElement(By.XPath("/html/body/div[1]/header/nav/div/div/div[5]/div"));
            Actions action = new(webDriver);
            action.MoveToElement(localizationButtonParrentElement).Perform();

            IWebElement localizationButton;

            switch (localization) {
                case Localization.SPANISH:
                    localizationButton = webDriver.FindElement(By.XPath("//*[@data-locale='es_ES']"));
                    localizationButton.Click();
                    break;
                case Localization.AMERICAN:
                    localizationButton = webDriver.FindElement(By.XPath("//*[@data-locale='en']"));
                    localizationButton.Click();
                    break;
                case Localization.BRITAIN:
                    localizationButton = webDriver.FindElement(By.XPath("//*[@data-locale='en_GB']"));
                    localizationButton.Click();
                    break;
                case Localization.GERMANY:
                    localizationButton = webDriver.FindElement(By.XPath("//*[@data-locale='de_DE']"));
                    localizationButton.Click();
                    break;
            }
            Thread.Sleep(7000);

            return this;
        }

        public string GetSupportHeaderText()
        {
            IWebElement supportHeader = webDriver.FindElement(By.Id("headingSupport"));
            return supportHeader.Text;
        }
    }
}