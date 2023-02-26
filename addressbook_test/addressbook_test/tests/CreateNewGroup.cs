using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    [TestFixture]
    public class GroupCreateTest : AuthTestBase
    {
        [Test]
        public void GroupCreateTests()
        {
            Form form = new Form("atest", "header", "footer");

            app.Navigator.GoToGroupsPage();
            List<Form> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(form.Name, form.Header, form.Footer);
            List<Form> newGroups = app.Groups.GetGroupList();
            app.Navigator.GoToHomePage();

            oldGroups.Add(form);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            Assert.AreEqual(oldGroups, newGroups);
        }

    }

}