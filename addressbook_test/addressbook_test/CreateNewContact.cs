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
            User user = new User("admin", "secret");
            Contact contact = new Contact("Alexey", "Spirin", "89236502869");
            string chapter = "add new";
            OpenPage(baseURL);
            LoginUser(user.Login, user.Pass);
            GoToChapter(chapter);
            CreateNewContact(contact.Firstname,contact.Lastname,contact.Mobile);
            GoToHomePage();
        }
    }
}
