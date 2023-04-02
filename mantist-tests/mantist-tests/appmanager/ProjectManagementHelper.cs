using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
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

        internal void DeleteProject(int index, int count)
        {
            if (count == 0)
            {
				CreateNewProject("From removal");
            }
            SelectProject(index);
			ClickButton(By.CssSelector("[value='Удалить проект']"));
            ClickButton(By.CssSelector("[value='Удалить проект']"));
        }

        private void SelectProject(int index)
        {
			driver.FindElement(By.XPath($"((//tbody)[1]/tr)["+(index+1)+"]/td/a")).Click();
        }
    }
}

