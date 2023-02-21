using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Reflection;

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
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            baseURL = "http://localhost/addressbook/index.php";

            loginHelper = new LoginHelper(this);
            navigation = new NavigationHelper(this);
            group = new GroupHelper(this);
            contacts = new ContactHelper(this);
        }

        ~ApplicationManager()
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

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {

                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenPage(newInstance.BaseUrl);
                app.Value = newInstance;


            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
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