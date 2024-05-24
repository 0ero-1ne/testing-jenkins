using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Lab11_12
{
    class LinkinParkCartPage
    {
        private IWebDriver webDriver;
        private WebDriverWait webDriverWait;
        private readonly string HomePageUrl = UrlUtils.HOME_PAGE;
        private readonly string CartPageUrl = UrlUtils.CART_PAGE;

        public LinkinParkCartPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            webDriverWait = new(webDriver, TimeSpan.FromSeconds(10));
        }

        public LinkinParkCartPage NavigateToHomePage()
        {
            webDriver.Navigate().GoToUrl(HomePageUrl);
            webDriverWait.Until(driver => driver.Url.Contains(HomePageUrl));
            return this;
        }

        public LinkinParkCartPage OpenProductPage()
        {
            var cardIconButton = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/section/div[2]/section/div/div[5]/div/div/div[1]/div[1]/a"));
            cardIconButton.Click();
            Thread.Sleep(5000);

            return this;
        }

        public LinkinParkCartPage AddGoodToCart()
        {
            var cardIconButton = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div[2]/div[6]/div[6]/div/div/button"));
            cardIconButton.Click();
            Thread.Sleep(5000);

            return this;
        }

        public LinkinParkCartPage OpenCartPage()
        {
            webDriver.Navigate().GoToUrl(CartPageUrl);
            webDriverWait.Until(driver => driver.Url.Contains(CartPageUrl));
            return this;
        }

        public LinkinParkCartPage EnterPromoCode()
        {
            var textField = webDriver.FindElement(By.Id("couponCode"));
            textField.SendKeys("ffff");
            var applyPromoButton = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[1]/div[2]/div[2]/div/form/div/div/div[2]/button"));
            applyPromoButton.Click();
            Thread.Sleep(5000);

            return this;
        }

        public bool IsPromoCodeEntered()
        {
            var taxTotal = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[1]/div[2]/div[6]/div[2]/p"));
            return taxTotal.Text == "-" ? true : false;
        }

        public bool IsProductInCart()
        {
            var products = webDriver.FindElements(By.XPath("//div[@class='line-item-name']"));
            return products.Count() > 0 ? true : false;
        }
    }
}