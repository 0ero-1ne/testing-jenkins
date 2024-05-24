using NUnit.Framework;

namespace Lab11_12
{
    class UnitTests : Setup
    {
        [Test]
        public void Test_Spanish_Localization_ReturnsTrue()
        {
            var expectedLoclizationResult = new LinkinParkStoreHomePage(driver!)
                .NavigateToHomePage()
                .SetStoreLocalization(Localization.SPANISH)
                .GetSupportHeaderText();

            Assert.That(expectedLoclizationResult, Is.EqualTo("AYUDA"));
            Logger.D("Spanish localization test completed");
        }

        [Test]
        public void Add_Prouct_To_Cart_ReturnsTrue()
        {
            var isProductInCard = new LinkinParkCartPage(driver!)
                .NavigateToHomePage()
                .OpenProductPage()
                .AddGoodToCart()
                .OpenCartPage()
                .IsProductInCart();

            Assert.That(isProductInCard, Is.EqualTo(true));
            Logger.D("Product successfully added to cart");
        }

        [Test]
        public void Is_Promo_Code_Wrong_ReturnsTrue()
        {
            var isProductInCard = new LinkinParkCartPage(driver)
                .NavigateToHomePage()
                .OpenProductPage()
                .AddGoodToCart()
                .OpenCartPage()
                .EnterPromoCode()
                .IsPromoCodeEntered();
            Assert.That(isProductInCard, Is.EqualTo(true));
            Logger.D("Wrong promocode is passed the test");
        }
    }
}