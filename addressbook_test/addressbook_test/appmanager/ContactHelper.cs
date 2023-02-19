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
		public ContactHelper(ApplicationManager manager):base(manager)
		{}

        public ContactHelper FillContactInfo(string firstname, string lastname, string mobile)
        {
            Type(By.Name("firstname"), firstname);
            Type(By.Name("lastname"), lastname);
            Type(By.Name("mobile"), mobile);
            return this;

        }

        public ContactHelper ClickEnter()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;

        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;

        }

        public ContactHelper ChooseElement(int index)
        {
            driver.FindElement(By.XPath($"(//input[@name='selected[]'])["+index+"]")).Click();
            return this;
        }

        public ContactHelper ModifyContact()
        {
            driver.FindElement(By.XPath("(//table[@id='maintable']/tbody//td//img[@title='Edit'])[1]")).Click();
            return this;
        }

        public ContactHelper ClickUpdate()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            return this;
        }
    }
}

