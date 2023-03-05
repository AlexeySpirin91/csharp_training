using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{

    [TestFixture]
    public class CreateContact : AuthTestBase
    {
        [Test]
        public void TheContactTest()
        {
            Contact contact = new Contact("Alexey", "Spirin");

            List<Contact> oldContacts = app.Contacts.GetContactList();
            app.Navigator.GoToContactPage();
            app.Contacts
                .FillContactInfo(contact.Firstname, contact.Lastname)
                .ClickEnter();

            
            List<Contact> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            app.Navigator.GoToHomePage();
        }

    }

}