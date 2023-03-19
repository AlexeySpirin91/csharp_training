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
            int index = 1;
            app.Navigator.GoToContactPage();
            Contact fromTable = app.Contacts.GetContactInformationFromTable(index);
            Contact fromForm = app.Contacts.GetContactInformationFromForm(index);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhone, fromForm.AllPhone);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);
        }
    }
}

