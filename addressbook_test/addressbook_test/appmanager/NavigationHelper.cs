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
    public class NavigationHelper : HelperBase
    {


        public NavigationHelper(ApplicationManager manager) : base(manager)
        { }

        public void OpenPage(string url)
        {
            if (driver.Url == "http://localhost/addressbook/index.php")
                return;
            driver.Navigate().GoToUrl(url);
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == "http://localhost/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
                return;
            driver.FindElement(By.XPath("//a[.='groups']")).Click();
        }

        public void GoToContactPage()
        {
            if (driver.Url == "http://localhost/addressbook/edit.php"
                && IsElementPresent(By.Name("submit")))
                return;
            driver.FindElement(By.XPath("//a[.='add new']")).Click();
        }

        public void GoToHomePage()
        {
            if (driver.Url == "http://localhost/addressbook/index.php"
                && IsElementPresent(By.Name("searchstring")))
                return;
            driver.FindElement(By.XPath("//a[.='home']")).Click();

        }
    }
}