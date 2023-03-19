using System;
using NUnit.Framework;
namespace addressbook_test
{
	public class RemoveContactFromGroupTest : AuthTestBase
    {
		public RemoveContactFromGroupTest()
		{
		}
        [Test]
		public void TestRemoveContactFromGroup()
		{
			Form form = Form.GetAll()[0];
            List<Contact> oldList = form.GetContacts();
            Contact contact = oldList.First();

            app.Contacts.RemoveContactFromGroup(contact, form);

            List<Contact> newList = form.GetContacts();
            oldList.Remove(contact);

            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}

