using System;
using NUnit.Framework;
namespace addressbook_test
{
	public class AddingContactToGroupTests : AuthTestBase
	{
		public AddingContactToGroupTests()
		{
		}
		[Test]
		public void TestAddingContactToGroup()
		{
            if (!app.Contacts.CheckContactOnPage())
			{
                Contact contactAdding = new Contact("Alexey_adding", "Spirin_adding");

                app.Navigator.GoToContactPage();
                app.Contacts
                    .FillContactInfo(contactAdding.Firstname, contactAdding.Lastname)
                    .ClickEnter();
                app.Navigator.GoToHomePage();
            }

            if (!app.Groups.CheckGroupForAdding())
            {
                Form formAdding = new Form("test_adding", "header_adding", "footer_adding");

                app.Navigator.GoToGroupsPage();
                app.Groups.Create(formAdding.Name, formAdding.Header, formAdding.Footer);
                app.Navigator.GoToHomePage();
            }

            Form form = Form.GetAll()[0];
			List<Contact> oldList = form.GetContacts();
            Contact contact = Contact.GetAll().Except(oldList).First();

			app.Contacts.AddContactToGroup(contact,form);

            List<Contact> newList = form.GetContacts();
			oldList.Add(contact);

			newList.Sort();
			oldList.Sort();

			Assert.AreEqual(oldList, newList);
        }
	}
}

