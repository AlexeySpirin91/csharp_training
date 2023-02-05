using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_test
{
    [TestFixture]
    public class GroupCreateTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

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

        [Test]
        public void GroupCreateTests()
        {
            User user = new User("admin", "secret");
            OpenPage(baseURL);
            LoginUser(user.Login, user.Pass);
            GoToChapter();
            CreateNewelement();
            FillForm("test", "test", "test");
            SubmitGroupCreation();
            ReturnTGrouopPage();
        }

        private void ReturnTGrouopPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void SubmitGroupCreation()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void FillForm(string name,string header,string footer)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(footer);
            driver.FindElement(By.Name("submit")).Click();
        }

        private void CreateNewelement()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        private void GoToChapter()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void LoginUser(string login, string pass)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).SendKeys(login);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(pass);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void OpenPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
