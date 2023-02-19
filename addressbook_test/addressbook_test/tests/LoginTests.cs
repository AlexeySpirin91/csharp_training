using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        public LoginTests()
        {
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            User user = new User("admin", "secret");
            app.Auth.Logout();
            app.Auth.LoginUser(user.Login, user.Pass);
            Assert.IsTrue(app.Auth.IsLoggedIn(user.Login));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            User user = new User("admin", "1234");
            app.Auth.Logout();
            app.Auth.LoginUser(user.Login, user.Pass);
            Assert.IsFalse(app.Auth.IsLoggedIn(user.Login));
        }
    }


}