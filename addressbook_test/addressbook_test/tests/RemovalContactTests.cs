using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test.tests
{
    [TestFixture]
    public class RemovalContactTests:TestBase
	{
		public RemovalContactTests()
		{
		}

        [Test]
        public void RemovalContactTest()
        {
            int num = 5;
            app.Contacts
                .ChooseContact(num)
                .DeleteContact();
        }
    }
}

