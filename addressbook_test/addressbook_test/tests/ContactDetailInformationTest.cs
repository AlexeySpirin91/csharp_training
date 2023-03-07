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
            Contact fromTable = app.Contacts.GetContactInformationFromTable(index);
            string fromDetails = app.Contacts.GetContactInformationFromDetails(index);

            Assert.AreEqual(fromTable.Alldata, fromDetails);
        }
	}
}

