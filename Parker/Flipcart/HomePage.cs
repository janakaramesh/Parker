using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipcartAutomation.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void CloseLoginPopup()
        {
            try
            {
                var closeBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'✕')]")));
                closeBtn.Click();
            }
            catch { }
        }

        public void ClickSection(string sectionName)
        {
            var section = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//div[text()='{sectionName}']")));
            section.Click();
        }

        public List<string> GetTop8Items()
        {
            var items = driver.FindElements(By.XPath("//div[contains(@class,'_4ddWXP')]//a[contains(@class,'s1Q9rs')]"));
            var result = new List<string>();

            for (int i = 0; i < Math.Min(8, items.Count); i++)
            {
                result.Add(items[i].Text);
            }

            return result;
        }
    }
}
    
