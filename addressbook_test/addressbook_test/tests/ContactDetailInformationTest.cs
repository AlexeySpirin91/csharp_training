using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    [TestFixture]
    public class ContactDetailInformationTest:AuthTestBase
	{
        [Test]
        public void TestContactDetailInformationTest()
		{
            int index = 0;
            app.Navigator.GoToContactPage();
            Contact fromTable = app.Contacts.GetContactInformationFromTable(0);
            string fromDetails = app.Contacts.GetContactInformationFromDetails(0);

            Console.WriteLine(fromTable.Alldata);
            Console.WriteLine(fromDetails);

            Assert.AreEqual(fromTable.Alldata, fromDetails);
        }
	}
}

