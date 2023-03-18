using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Google.Protobuf.WellKnownTypes;
using NUnit.Framework;

namespace addressbook_test
{
    public class ContactTestBase : AuthTestBase
    {
        public ContactTestBase()
        {
        }
        [TearDown]
        public void CompareContactUI_DB()
        {
            if (PERFOM_LONG_UI_CHECKS)
            {
                List<Contact> fromUI = app.Contacts.GetContactList();
                List<Contact> fromDB = Contact.GetAll();

                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}


