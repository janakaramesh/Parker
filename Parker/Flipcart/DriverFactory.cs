using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipcartAutomation.Utilities
{
    public class DriverFactory
    {
        public static IWebDriver InitDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--remote-allow-origins=*");

            return new ChromeDriver(options);
        }
    }
}
    
