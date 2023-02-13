using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_test
{
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            User user = new User("admin", "secret");
            app = new ApplicationManager();
            app.Navigator.OpenPage(app.BaseUrl);
            app.Auth.LoginUser(user.Login, user.Pass);
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }

}