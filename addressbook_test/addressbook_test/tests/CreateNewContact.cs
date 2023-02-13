using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    [TestFixture]
    public class CreateContact : TestBase
    {
        [Test]
        public void TheContactTest()
        {

            Contact contact = new Contact("Alexey", "Spirin", "89236502869");
            string chapter = "add new";

            app.Navigator.GoToChapter(chapter);
            app.Contacts.CreateNewContact(contact.Firstname,contact.Lastname,contact.Mobile);
            app.Navigator.GoToChapter(chapter);
        }
    }
}
