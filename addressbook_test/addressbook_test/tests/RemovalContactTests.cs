using System;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_test
{
    [TestFixture]
    public class RemovalContactTests: ContactTestBase
    {
		public RemovalContactTests()
		{
		}

        [Test]
        public void RemovalContactTest()
        {
            int index = 2;

            app.Navigator.GoToHomePage();

            if (!app.Contacts.CheckContactOnPage())
            {
                Contact contact = new Contact("Alexey_removal", "Spirin_removal");

                app.Navigator.GoToContactPage();
                app.Contacts
                    .FillContactInfo(contact.Firstname, contact.Lastname)
                    .ClickEnter();
                app.Navigator.GoToHomePage();
            }
            List<Contact> oldContacts = Contact.GetAll();
            Contact toBeRemoved = oldContacts[index];
            app.Contacts.Remove(toBeRemoved);
            List<Contact> newContacts = Contact.GetAll();

            oldContacts.RemoveAt(index);

            Assert.AreEqual(oldContacts, newContacts);

            app.Navigator.GoToHomePage();

        }
    }
}

