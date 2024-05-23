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
        public void Test_Germany_Localization_ReturnsTrue()
        {
            var expectedLoclizationResult = new LinkinParkStoreHomePage(driver!)
                .NavigateToHomePage()
                .SetStoreLocalization(Localization.GERMANY)
                .GetSupportHeaderText();

            Assert.That(expectedLoclizationResult, Is.EqualTo("Kundenservice".ToUpper()));
            Logger.D("Germany localization test completed");
        }

        [Test]
        public void Test_Britain_Localization_ReturnsTrue()
        {
            var expectedLoclizationResult = new LinkinParkStoreHomePage(driver!)
                .NavigateToHomePage()
                .SetStoreLocalization(Localization.BRITAIN)
                .GetSupportHeaderText();

            Assert.That(expectedLoclizationResult, Is.EqualTo("SUPPORT"));
            Logger.D("Britain localization test completed");
        }
    }
}