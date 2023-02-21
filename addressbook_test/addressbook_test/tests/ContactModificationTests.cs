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
            Contact newContact = new Contact("Alexey_new", "Spirin_new", "89236502867");
            Contact contact = new Contact("Alexey_modif", "Spirin_modif", "89236502866");

            app.Navigator.GoToHomePage();

            if (app.Contacts.CheckContactOnPage())
            {
                app.Contacts
                .ModifyContact()
                .FillContactInfo(newContact.Firstname, newContact.Lastname, newContact.Mobile)
                .ClickUpdate();
            }
            else
            {
                app.Navigator.GoToContactPage();
                app.Contacts
                    .FillContactInfo(contact.Firstname, contact.Lastname, contact.Mobile)
                    .ClickEnter();
                app.Navigator.GoToHomePage();
                app.Contacts
                    .ModifyContact()
                    .FillContactInfo(newContact.Firstname, newContact.Lastname, newContact.Mobile)
                    .ClickUpdate();
            }
            
            app.Navigator.GoToHomePage();
        }
    }


}