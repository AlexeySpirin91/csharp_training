using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using addressbook_test;
using Google.Protobuf.WellKnownTypes;
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
        public ContactHelper ChooseElement(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }

        public ContactHelper ModifyContact(int index)
        {
            driver.FindElement(By.XPath("(//table[@id='maintable']/tbody//td//img[@title='Edit'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper ModifyContact(string id)
        {
            driver.FindElement(By.XPath("(//input[@value='"+id+"']//ancestor::tr //a//img[@title='Edit'])")).Click();
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

            string allData = (driver.FindElement(By.Id("content")).Text);
            return allData;
        }

        public string GetContactInformationFromFormForDetails(int index)
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

            string fio;
            if (firstName == "" && lastName == "")
                fio = "";
            else if (firstName != "" && lastName == "")
                fio =  firstName + "\n";
            else if (firstName == "" && lastName != "")
                fio = lastName + "\n";
            else
                fio = firstName + " " + lastName + "\n";

            if (homePhone != "")
                homePhone = "H: " + homePhone + "\n";
            if (mobilePhone != "")
                mobilePhone = "M: " + mobilePhone + "\n";
            if (workPhone != "")
                workPhone = "W: " + workPhone + "\n";

            if (email != "" && email2 != "" && email3 != "")
                email = email + "\n";
            if (email2 != "" && email3 != "")
                email2 = email2 + "\n";

            string allPhones = homePhone + mobilePhone + workPhone;
            string allEmails = email + email2 + email3;

            if (address == "" && (allPhones !="" || allEmails !=""))
                address = "\n";
            else if (address == "" && allPhones == "" && allEmails == "")
                address = "";
            else address = address + "\n\n";

            if (allPhones != "" && allEmails != "") { allPhones = allPhones + "\n"; }
            if (allPhones != "" && allEmails == "") { allPhones = allPhones.Substring(0, allPhones.Length - 1); }
            if (address =="" && allPhones == "" && allEmails == "") { fio = fio.Substring(0, fio.Length - 1); }

            string info = fio + address + allPhones + allEmails;

            return info;
        }

        public void Remove(Contact contact)
        {
            ChooseElement(contact.Id);
            DeleteContact();
        }

        public void ModifyContact(Contact contact, string firstname, string lastname)
        {
            ModifyContact(contact.Id);
            FillContactInfo(firstname, lastname);
            ClickUpdate();
        }

        public void AddContactToGroup(Contact contact, Form form)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(form.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void RemoveContactToGroup(Contact contact, Form form)
        {
            manager.Navigator.GoToHomePage();
            SelectGroup(form.Name);
            SelectContact(contact.Id);
            CommitRemoveContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitRemoveContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void SelectGroup(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }



        public void RemoveContactToGroupTest(string name)
        {
            manager.Navigator.GoToHomePage();
            SelectGroup(name);
            CommitRemoveContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }
    }
}

