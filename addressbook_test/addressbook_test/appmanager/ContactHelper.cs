using System;
using System.Collections.Generic;
using System.Numerics;
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
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        { }

        public ContactHelper FillContactInfo(string firstname, string lastname)
        {
            Type(By.Name("firstname"), firstname);
            Type(By.Name("lastname"), lastname);
        
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
                    IList < IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new Contact(cells[2].Text, cells[1].Text));
                }
            }
            
            
            return new List<Contact>(contactCache);
        }

        public Contact GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string firstName = cells[2].Text;
            string lastName = cells[1].Text;
            string address = cells[3].Text;

            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new Contact(firstName, lastName)
            {
                Address = address,
                AllPhone = allPhones,
                AllEmail = allEmails
            };

        }

        public Contact GetContactInformationFromForm(int index)
        {
            manager.Navigator.GoToHomePage();
            ModifyContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new Contact(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public string GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6]
            .FindElement(By.TagName("a")).Click();

            string allData = (driver.FindElement(By.Id("content")).Text).Trim();
            return Regex.Replace(allData, "[ -()HMW:\n]", "");
        }
    }


}