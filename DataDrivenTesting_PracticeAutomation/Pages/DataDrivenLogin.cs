using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataDrivenTesting_PracticeAutomation.Pages
{
    public class DataDrivenLogin : CorePage
    {
        By username = By.XPath("//input[@id='user-name']");
        By password = By.XPath("//input[@id='password']");
        By loginbutton = By.XPath("//input[@id='login-button']");
        By afterlogin = By.XPath("//span[normalize-space()='Products']");
        //string enterUN = "standard_user";
        //string enterPW = "secret_sauce";
        //string enterUN = TestContext.DataRow["enterUsername"].ToString();



        public void LoginDD(string url, string enterUN, string enterPW)
        {
            IJavaScriptExecutor scroll = (IJavaScriptExecutor)driver;
            //Action Actions = new Action(driver);

            //maximize the window
            driver.Manage().Window.Maximize();

            //open application
            driver.Url = url;
            Thread.Sleep(1000);
            //print the url
            Console.WriteLine("URL of the application:" + " " + url);
            Console.WriteLine();
            //print the title
            string title = driver.Title;
            Console.WriteLine("Title of the page:" + " " + title);
            Console.WriteLine();

            //wait
            var waituntilusername = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waituntilusername.Until(ExpectedConditions.ElementIsVisible(username));

            //enter username
            driver.FindElement(username).SendKeys(enterUN);
            //enter password
            driver.FindElement(password).SendKeys(enterPW);

            //wait login button
            var waituntilloginbtn = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waituntilloginbtn.Until(ExpectedConditions.ElementIsVisible(loginbutton));

            //click login button
            driver.FindElement(loginbutton).Click();

            // wait login button
            var waituntilpageloads = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waituntilpageloads.Until(ExpectedConditions.UrlContains("inventory.html"));

            //Assert successfully logged in
            Assert.IsTrue(driver.Url.Contains("inventory.html"));

        }

    }
}

