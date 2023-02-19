using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
	[SetUpFixture]

	public class TestSuiteFixture
	{
		[OneTimeSetUp]
		public void InitApplicationManager()
		{
            User user = new User("admin", "secret");
            ApplicationManager app = ApplicationManager.GetInstance();

            app.Auth.LoginUser(user.Login, user.Pass);
        }
    }
}

