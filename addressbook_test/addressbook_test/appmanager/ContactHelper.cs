using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_test
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        { }

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
            contactCache = null;
            return this;

        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;

        }

        public ContactHelper ChooseElement(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper ModifyContact(int index)
        {
            driver.FindElement(By.XPath("(//table[@id='maintable']/tbody//td//img[@title='Edit'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper ClickUpdate()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            contactCache = null;
            return this;
        }

        public bool CheckContactOnPage()
        {
            if (driver.Url == "http://localhost/addressbook/index.php"
                && IsElementPresent(By.XPath("//table[@id='maintable']/tbody//td//img[@title='Edit']")))
                return true;
            return false;
        }

        private List<Contact> contactCache = null;

        public List<Contact> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<Contact>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    string[] contactInfo = element.Text.Split(new char[] { ' ' });
                    contactCache.Add(new Contact(contactInfo[1], contactInfo[0], contactInfo[2]));
                }
            }
            
            
            return new List<Contact>(contactCache);
        }
    }


}