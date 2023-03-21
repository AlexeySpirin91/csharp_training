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
            List<Form> forms = Form.GetAll();
            int count = 0;
            foreach (Form form in forms)
            {
                List<Contact> oldList = form.GetContacts();
                List<Contact> allContacts = Contact.GetAll();
                List<Contact> allContactsInGroup = new List<Contact>();

                for (int i = 0; i < allContacts.Count(); i++)
                {
                    if (oldList.Contains(allContacts[i]))
                    {
                        allContactsInGroup.Add(allContacts[i]);
                        count++;
                    }
                }
                if (allContactsInGroup.Count() == 0) Console.WriteLine($"{form.Name}в этой группе нет контактов");
                else
                {
                    Contact contact = oldList.First();

                    app.Contacts.RemoveContactFromGroup(contact, form);

                    List<Contact> newList = form.GetContacts();
                    oldList.Remove(contact);

                    newList.Sort();
                    oldList.Sort();
                    Assert.AreEqual(oldList, newList);
                    break;
                }

                if (count == 0)
                {
                    Console.WriteLine("ни в одной группе нет контактов");
                }
            }
        }
    }
}

