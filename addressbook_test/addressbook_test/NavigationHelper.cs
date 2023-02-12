﻿using System;
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


        public NavigationHelper(IWebDriver driver):base(driver)
		{}

        public void OpenPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void GoToChapter(string chapter)
        {
            driver.FindElement(By.LinkText(chapter)).Click();
        }

    }
}

