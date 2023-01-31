using DataDrivenTesting_PracticeAutomation.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataDrivenTesting_PracticeAutomation
{
    [TestClass]
    public class TestCases : CorePage
    {
        LoginTest ddlogin = new LoginTest();
        DataDrivenLogin logindd = new DataDrivenLogin();

      
            #region Setups and Cleanups
        public TestContext instance;
       

        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        //Before every class
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {

        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {


        }

        //The TestInitialize attribute is needed when we want to run a function before executing a test.
        [TestInitialize]
        public void TestInit()
        {
            //The driver should always be called in the Test Initialize method
            CorePage.SeleniumInit();
        }

        //The TestCleanup will run after every test execution.
        [TestCleanup]
        public void TestCleanUp()
        {
            driver.Quit();
        }
        #endregion



        [TestMethod]
      
        public void DataDrivenLoginTestCase01()
        {
            ddlogin.DataDrivenLogin("https://www.saucedemo.com/", "standard_user", "secret_sauce");
        }

        [TestMethod]

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "DataDrivenLoginTestCase02", DataAccessMethod.Sequential)]
        public void DataDrivenLoginTestCase02()
        {
            string enterUN = TestContext.DataRow["enterUsername"].ToString();
            string enterPW = TestContext.DataRow["enterPassword"].ToString();

            logindd.LoginDD("https://www.saucedemo.com/", enterUN, enterPW);
        }



    }

}