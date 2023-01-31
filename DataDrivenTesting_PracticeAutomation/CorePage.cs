using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDrivenTesting_PracticeAutomation
{
    public class CorePage
    {
        public static IWebDriver driver;

        public static IWebDriver SeleniumInit()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            driver = chromeDriver;
            return driver;
        }
    }
}
