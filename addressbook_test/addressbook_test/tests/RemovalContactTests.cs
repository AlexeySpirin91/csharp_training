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
            int index = 5;
            app.Contacts
                .ChooseElement(index)
                .DeleteContact();
        }
    }
}

