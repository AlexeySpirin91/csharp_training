using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        public ContactModificationTests()
        {
        }

        [Test]
        public void ContactModificationTest()
        {
            Contact newContact = new Contact("Alexey_new", "Spirin", "89236502868");

            app.Contacts
                .ModifyContact()
                .FillContactInfo(newContact.Firstname, newContact.Lastname, newContact.Mobile)
                .ClickUpdate();
        }
    }


}