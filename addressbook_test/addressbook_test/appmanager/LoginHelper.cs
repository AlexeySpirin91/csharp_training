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

        public LoginHelper(ApplicationManager manager):base(manager)
		{}

        public void LoginUser(string login, string pass)
        {
            Type(By.Name("user"), login);
            Type(By.Name("pass"), pass);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
    }
}