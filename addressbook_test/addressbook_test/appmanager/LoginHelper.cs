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
	public class LoginHelper:HelperBase
	{

        public LoginHelper(IWebDriver driver):base(driver)
		{}

        public void LoginUser(string login, string pass)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).SendKeys(login);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(pass);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
    }
}