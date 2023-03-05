using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            app.Navigator.GoToContactPage();
            Contact fromTable = app.Contacts.GetContactInformationFromTable(0);
            Contact fromForm = app.Contacts.GetContactInformationFromForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhone, fromForm.AllPhone);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);
        }
    }
}

