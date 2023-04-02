using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantist_tests
{
	public class ProjectManagementHelper:HelperBase
	{
		public ProjectManagementHelper(ApplicationManager manager):base(manager)
		{
		}

		

		public void CreateNewProject(string name)
		{
			ClickButton(By.CssSelector("[class='btn btn-primary btn-white btn-round']"));
			FillProjectInfo(name);
			ClickButton(By.CssSelector("[class='btn btn-primary btn-white btn-round']"));
		}

        private void FillProjectInfo(string name)
        {
			Type(By.Name("name"), name);
        }

        public void ClickButton(By locator)
		{
			driver.FindElement(locator).Click();
		}
	}
}

