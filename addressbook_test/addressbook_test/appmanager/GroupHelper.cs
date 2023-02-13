using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
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

        public GroupHelper Create(string name, string header, string footer)
        {


            ChooseAction("new");
            FillForm(name, header, footer);
            SubmitGroupCreation();
            return this;

        }

        public GroupHelper RemovalGroup(int num)
        {            
            ChooseElement(num);
            ChooseAction("delete");
            return this;
        }

        public GroupHelper Modify(int index, string name, string header, string footer)
        {
            ChooseElement(index);
            ChooseAction("edit");
            FillForm(name, header, footer);
            SubmitGroupModification();
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
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        private GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;

        }

        public GroupHelper ChooseAction(string action)
        {
            driver.FindElement(By.Name(action)).Click();
            return this;
        }

        public GroupHelper ChooseElement(int index)
        {
            driver.FindElement(By.XPath($"(//input[@name='selected[]'])["+index+"]")).Click();
            return this;
        }
    }
}

