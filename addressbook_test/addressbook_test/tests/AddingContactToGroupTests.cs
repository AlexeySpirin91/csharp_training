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

