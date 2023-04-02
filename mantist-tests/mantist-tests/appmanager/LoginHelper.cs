using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
	public class LoginHelper:HelperBase
	{
		public LoginHelper(ApplicationManager manager):base(manager)
		{
		}

		public void LoginUser(string login, string pass)
		{
            if (IsLoggedIn())
            {
                return;
            }
			Type(By.Name("username"), login);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            Type(By.Name("password"), pass);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.ClassName("user-info"));
        }
    }
}

