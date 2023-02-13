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
	public class GroupHelper:HelperBase
	{

        public GroupHelper(ApplicationManager manager):base(manager)
		{}

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper FillForm(string name, string header, string footer)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(footer);
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillNewElement()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
    }
}

