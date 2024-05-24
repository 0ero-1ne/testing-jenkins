using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Lab9
{
    public class UnitTests
    {
        private IWebDriver webDriver;
        private StringBuilder verificationError;

        [SetUp]
        public void Setup()
        {
            webDriver = new FirefoxDriver();
            verificationError = new StringBuilder();
        }

        [TearDown]
        public void TearDownTest()
        {
            try
            {
                webDriver.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Assert.That(verificationError.ToString(), Is.EqualTo(""));
        }

        [Test]
        public void Test_Spanish_Localization_ReturnsTrue()
        {
            webDriver.Navigate().GoToUrl("https://linkinpark.warnerrecords.com/");

            WebDriverWait wait = new(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.Url.Contains("https://linkinpark.warnerrecords.com/"));

            var localizationButtonParrentElement = webDriver.FindElement(By.XPath("/html/body/div[1]/header/nav/div/div/div[5]/div"));
            Actions action = new(webDriver);
            action.MoveToElement(localizationButtonParrentElement).Perform();

            IWebElement localizationButton = webDriver.FindElement(By.XPath("//*[@data-locale='es_ES']"));
            localizationButton.Click();
            wait.Until(driver => driver.Url.Contains("https://linkinpark.warnerartists.net/es/"));
            Thread.Sleep(3000);

            IWebElement localHeader = webDriver.FindElement(By.XPath("//*[@id='headingSupport']"));
            Assert.That(localHeader.Text, Is.EqualTo("AYUDA"));
        }
    }
}