using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{

    [TestFixture]
    public class CreateContact : AuthTestBase
    {
        [Test]
        public void TheContactTest()
        {
            Contact contact = new Contact("Alexey", "Spirin", "89236502868");
            string chapter = "add new";

            app.Navigator.GoToChapter(chapter);
            app.Contacts
                .FillContactInfo(contact.Firstname, contact.Lastname, contact.Mobile)
                .ClickEnter();
        }
    }

}