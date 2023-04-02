using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
	public class ManagementMenuHelper:HelperBase
	{
		public ManagementMenuHelper(ApplicationManager manager):base(manager)
		{
		}
		public void GoToManagement()
		{
			driver.FindElement(By.ClassName("fa-gears")).Click();
		}

        public void GoToProjectManagement()
        {
            driver.FindElement(By.XPath("//*[@href='/mantisbt-2.25.6/manage_proj_page.php']")).Click();
        }

    }
}

