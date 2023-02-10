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

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/index.php";
            verificationErrors = new StringBuilder();
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

        protected void ReturnTGrouopPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void SubmitGroupCreation()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void FillForm(string name, string header, string footer)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(footer);
            driver.FindElement(By.Name("submit")).Click();
        }

        protected void FillNewElement()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        protected void GoToChapter(string chapter)
        {
            driver.FindElement(By.LinkText(chapter)).Click();
        }

        protected void LoginUser(string login, string pass)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).SendKeys(login);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(pass);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        protected void OpenPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        protected void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

        protected void CreateNewContact(string firstname, string lastname, string mobile)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(lastname);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(mobile);
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }
    }

}