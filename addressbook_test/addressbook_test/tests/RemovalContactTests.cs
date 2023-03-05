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
            int index = 0;

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
            List<Contact> oldContacts = app.Contacts.GetContactList();

            app.Contacts
                    .ChooseElement(index)
                    .DeleteContact();

            List<Contact> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(index);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            app.Navigator.GoToHomePage();

        }
    }
}

