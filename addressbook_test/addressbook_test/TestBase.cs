using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_test
{
    public class TestBase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;

        protected  LoginHelper loginHelper;
        protected NavigationHelper navigation;
        protected GroupHelper group;
        protected ContactHelper contacts;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/index.php";
            verificationErrors = new StringBuilder();

            loginHelper = new LoginHelper(driver);
            navigation = new NavigationHelper(driver);
            group = new GroupHelper(driver);
            contacts = new ContactHelper(driver);
            
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());

        }
    }

}