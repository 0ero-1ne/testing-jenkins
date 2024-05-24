using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Lab10
{
    class UnitTests
    {
        private IWebDriver webDriver;

        [SetUp]
        public void Setup()
        {
            webDriver = new FirefoxDriver();
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
        }

        [Test]
        public void Test_Spanish_Localization_ReturnsTrue()
        {
            var expectedLoclizationResult = new LinkinParkStoreHomePage(webDriver)
                .NavigateToHomePage()
                .SetStoreLocalization(Localization.SPANISH)
                .GetSupportHeaderText();

            Assert.That(expectedLoclizationResult, Is.EqualTo("AYUDA"));
        }

        [Test]
        public void Add_Prouct_To_Cart_ReturnsTrue()
        {
            var isProductInCard = new LinkinParkCartPage(webDriver)
                .NavigateToHomePage()
                .OpenProductPage()
                .AddGoodToCart()
                .OpenCartPage()
                .IsProductInCart();
            Assert.That(isProductInCard, Is.EqualTo(true));
        }

        // [Test]
        // public void Is_Promo_Code_Wrong_ReturnsTrue()
        // {
        //     var isProductInCard = new LinkinParkCartPage(webDriver)
        //         .NavigateToHomePage()
        //         .OpenProductPage()
        //         .AddGoodToCart()
        //         .OpenCartPage()
        //         .EnterPromoCode()
        //         .IsPromoCodeEntered();
        //     Assert.That(isProductInCard, Is.EqualTo(true));
        // }
    }
}