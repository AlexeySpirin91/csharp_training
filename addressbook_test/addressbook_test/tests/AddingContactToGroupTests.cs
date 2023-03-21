using System;
using NUnit.Framework;
using static LinqToDB.Sql;

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

            List<Form> forms = Form.GetAll();
            int count = 0;
            foreach (Form form in forms)
            {
                List<Contact> oldList = form.GetContacts();
                List<Contact> allContacts = Contact.GetAll();
                List<Contact> allContactsInGroup = new List<Contact>();

                for (int i = 0; i < allContacts.Count(); i++)
                {
                    if (!oldList.Contains(allContacts[i]))
                    {
                        allContactsInGroup.Add(allContacts[i]);
                        count++;
                    }
                }
                if (allContactsInGroup.Count() == 0) Console.WriteLine("в эту группу добавлены все контакты");
                else
                {
                    Contact contact = allContactsInGroup.First();
                    app.Contacts.AddContactToGroup(contact, form);

                    List<Contact> newList = form.GetContacts();
                    oldList.Add(contact);

                    newList.Sort();
                    oldList.Sort();

                    Assert.AreEqual(oldList, newList);
                    break;
                }

                if(count == 0)
                {
                    Console.WriteLine("Все контакты добавлены во все группы");
                }
            }

            

			
        }
	}
}

