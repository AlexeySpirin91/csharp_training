using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test.tests
{
    [TestFixture]
    public class ContactModificationTests:TestBase
	{
		public ContactModificationTests()
		{
		}

        [Test]
        public void ContactModificationTest()
        {
            Contact newContact = new Contact("Alexey_new", "Spirin", "89236502869");


            app.Contacts
                .ModifyContact()
                .FillContactInfo(newContact.Firstname, newContact.Lastname, newContact.Mobile)
                .ClickUpdate();
        }
    }
}

