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
	public class ApplicationManager
	{
        private IWebDriver driver;
        private string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigation;
        protected GroupHelper group;
        protected ContactHelper contacts;

        public ApplicationManager()
		{
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/index.php";

            loginHelper = new LoginHelper(driver);
            navigation = new NavigationHelper(driver);
            group = new GroupHelper(driver);
            contacts = new ContactHelper(driver);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigation;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return group;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return contacts;
            }
        }

        public string BaseUrl
        {
            get
            {
                return baseURL;
            }
        }
    }
}

