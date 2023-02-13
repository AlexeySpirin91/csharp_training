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
	public class ContactHelper:HelperBase
	{
		public ContactHelper(IWebDriver driver):base(driver)
		{}

        public void CreateNewContact(string firstname, string lastname, string mobile)
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

