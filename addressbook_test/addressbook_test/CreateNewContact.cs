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
    [TestFixture]
    public class CreateContact
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
        public void TheContactTest()
        {
            User user = new User("admin", "secret");
            Contact contact = new Contact("Alexey", "Spirin", "89236502869");
            OpenPage(baseURL);
            LoginUser(user.Login, user.Pass);
            GoToChapter();
            CreateNewContact(contact.Firstname,contact.Lastname,contact.Mobile);
            GoToHomePage();
        }

        private void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

        private void CreateNewContact(string firstname, string lastname, string mobile)
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

        private void GoToChapter()
        {
            driver.FindElement(By.LinkText("add new")).Click();
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
