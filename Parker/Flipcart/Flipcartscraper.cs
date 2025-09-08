using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using SeleniumExtras.WaitHelpers;

class FlipkartScraper
{
    static IWebDriver driver;

    static void Main(string[] args)
    {
        // Setup ChromeDriver
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("start-maximized");
        driver = new ChromeDriver(options);

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        // Navigate to Flipkart
        driver.Navigate().GoToUrl("https://www.flipkart.com");

        // Close login popup if it appears
        // Close login popup if it appears
        try
        {
            var closeBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'✕')]")));
            closeBtn.Click();
        }
        catch { }

        // Example 1: Get products under "Best of Electronics"
        List<string> electronics = GetProductsUnderSection("Best of Electronics");
        Console.WriteLine("=== Best of Electronics ===");
        foreach (string item in electronics)
        {
            Console.WriteLine(item);
        }

        // Example 2: Get products under "Beauty, Food, Toys & more"
        List<string> beauty = GetProductsUnderSection("Beauty, Food, Toys & more");
        Console.WriteLine("\n=== Beauty, Food, Toys & more ===");
        foreach (string item in beauty)
        {
            Console.WriteLine(item);
        }

        // Close driver
        driver.Quit();
    }

    public static List<string> GetProductsUnderSection(string sectionName)
    {
        // Dynamic XPath: finds the section heading and gets the product names under it
        string sectionXpath = $"//div[contains(text(),'{sectionName}')]/following::div[1]//div[@class='_2kSfQ4']";

        IReadOnlyCollection<IWebElement> productElements = driver.FindElements(By.XPath(sectionXpath));

        List<string> productNames = new List<string>();

        foreach (var product in productElements)
        {
            string text = product.Text.Trim();
            if (!string.IsNullOrEmpty(text))
            {
                productNames.Add(text);
            }
        }

        return productNames;
    }
}