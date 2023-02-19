using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    public class AuthTestBase : TestBase
    {
        public AuthTestBase()
        {
        }
        [SetUp]
        public void SetupLogin()
        {
            User user = new User("admin", "secret");
            app.Auth.LoginUser(user.Login, user.Pass);
        }
    }
}



