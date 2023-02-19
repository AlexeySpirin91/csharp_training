using System;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_test
{
    [TestFixture]
    public class RemovalContactTests:AuthTestBase
	{
		public RemovalContactTests()
		{
		}

        [Test]
        public void RemovalContactTest()
        {
            int index = 1;

            app.Contacts
                .ChooseElement(index)
                .DeleteContact();
            app.Navigator.GoToHomePage();

        }
    }
}

