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
            int index = 1;

            app.Navigator.GoToContactPage();

            if (app.Contacts.CheckContactOnPage())
            {
                app.Contacts
                    .ChooseElement(index)
                    .DeleteContact();
            }
            else
            {
                Contact contact = new Contact("Alexey_removal", "Spirin_removal", "89236502868");

                app.Navigator.GoToContactPage();
                app.Contacts
                    .FillContactInfo(contact.Firstname, contact.Lastname, contact.Mobile)
                    .ClickEnter();
                app.Navigator.GoToHomePage();
                app.Contacts
                    .ChooseElement(index)
                    .DeleteContact();
            }
            app.Navigator.GoToHomePage();

        }
    }
}

