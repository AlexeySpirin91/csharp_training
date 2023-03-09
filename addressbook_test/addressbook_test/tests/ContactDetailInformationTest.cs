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
            int index = 3;
            app.Navigator.GoToContactPage();
            string fromForm = app.Contacts.GetContactInformationFromFormForDetails(index);
            string fromDetails = app.Contacts.GetContactInformationFromDetails(index);

            Console.WriteLine(fromForm);

            Assert.AreEqual(fromForm, fromDetails);
        }
	}
}

