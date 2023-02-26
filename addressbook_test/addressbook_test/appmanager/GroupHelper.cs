using System;
using System.Reflection;
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
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        { }

        public GroupHelper Create(string name, string header, string footer)
        {
            ChooseAction("new");
            FillForm(name, header, footer);
            SubmitGroupCreation();
            return this;

        }

        public GroupHelper RemovalGroup(int index)
        {
            ChooseElement(index);
            ChooseAction("delete");
            groupCache = null;
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
            Type(By.Name("group_name"), name);
            Type(By.Name("group_header"), header);
            Type(By.Name("group_footer"), footer);
            return this;
        }



        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        private GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;

        }

        public GroupHelper ChooseAction(string action)
        {
            driver.FindElement(By.Name(action)).Click();
            return this;
        }

        public GroupHelper ChooseElement(int index)
        {
            driver.FindElement(By.XPath($"(//input[@name='selected[]'])[" + (index +1) + "]")).Click();
            return this;
        }

        public bool CheckGroupOnPage()
        {
            if (driver.Url == "http://localhost/addressbook/group.php"
                && IsElementPresent(By.XPath("//input[@name='selected[]']")))
                return true;
            return false;
        }

        private List<Form> groupCache = null;

        public List<Form> GetGroupList()
        {
            if(groupCache == null)
            {
                groupCache = new List<Form>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {

                    groupCache.Add(new Form(element.Text, "", ""));
                }
            }
            

            return new List<Form>(groupCache);
        }
    }


}