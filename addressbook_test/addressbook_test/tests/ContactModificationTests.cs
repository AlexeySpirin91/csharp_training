using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        public ContactModificationTests()
        {
        }

        [Test]
        public void ContactModificationTest()
        {
            int index = 9;
            Contact newContact = new Contact("Alexey_new_hoba", "Spirin_new_ololo");
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

            List<Contact> oldContacts = Contact.GetAll();
            Contact toBeModify = oldContacts[index];
            app.Contacts.ModifyContact(toBeModify, newContact.Firstname, newContact.Lastname);
            List<Contact> newContacts = Contact.GetAll();

            oldContacts[index].Firstname = newContact.Firstname;
            oldContacts[index].Lastname = newContact.Lastname;

            Assert.AreEqual(oldContacts, newContacts);

            app.Navigator.GoToHomePage();
        }
    }
}