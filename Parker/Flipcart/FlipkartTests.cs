using FlipcartAutomation.Pages;
using FlipcartAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using NUnit.Framework.Legacy;

namespace FlipkartAutomation.Tests
{
    [TestFixture]
    public class FlipkartTests
    {
        IWebDriver driver;
        HomePage home;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.InitDriver();
            driver.Navigate().GoToUrl("https://www.flipkart.com");
            home = new HomePage(driver);
            home.CloseLoginPopup();
        }

        [Test]
        [TestCase("Mobiles & Tablets")]
        [TestCase("Fashion")]
        [TestCase("Electronics")]
        [TestCase("Home & Furniture")]
        [TestCase("TVs & Appliances")]
        [TestCase("Flight Bookings")]
        [TestCase("Beauty")]
        [TestCase("Grocery")]
        public void RetrieveTop8ItemsFromSection(string sectionName)
        {
            home.ClickSection(sectionName);
            var items = home.GetTop8Items();

            TestContext.WriteLine($"Section: {sectionName}");
            foreach (var item in items)
            {
                TestContext.WriteLine($"- {item}");
            }

            ClassicAssert.IsTrue(items.Count > 0, $"No items found in section: {sectionName}");
            driver.Navigate().Back();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
