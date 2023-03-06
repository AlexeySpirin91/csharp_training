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
            int index = 1;
            Contact newContact = new Contact("Alexey_new", "Spirin_new");
            Contact contact = new Contact("Alexey_modif", "Spirin_modif");

            app.Navigator.GoToHomePage();

            if (!app.Contacts.CheckContactOnPage())
            {
                app.Navigator.GoToContactPage();
                app.Contacts
                    .FillContactInfo(contact.Firstname, contact.Lastname)
                    .ClickEnter();
                app.Navigator.GoToHomePage();
            }

            List<Contact> oldContacts = app.Contacts.GetContactList();
            app.Contacts
                    .ModifyContact(index)
                    .FillContactInfo(newContact.Firstname, newContact.Lastname)
                    .ClickUpdate();


            List<Contact> newContacts = app.Contacts.GetContactList();

            oldContacts[index].Firstname = newContact.Firstname;
            oldContacts[index].Lastname = newContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            app.Navigator.GoToHomePage();
        }
    }


}