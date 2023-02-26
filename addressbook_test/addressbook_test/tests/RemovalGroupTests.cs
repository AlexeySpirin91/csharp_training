using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    [TestFixture]
    public class RemovalGroupTests:AuthTestBase
	{
		public RemovalGroupTests()
		{
		}

        [Test]
        public void GroupRemovalTest()
        {
            int index = 0;
            

            app.Navigator.GoToGroupsPage();

            if (!app.Groups.CheckGroupOnPage())
            {
                Form form = new Form("test_removal", "header_removal", "footer_removal");

                app.Groups.Create(form.Name, form.Header, form.Footer);
                app.Navigator.GoToGroupsPage();
            }

            List<Form> oldGroups = app.Groups.GetGroupList();

            app.Groups.RemovalGroup(index);

            List<Form> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(index);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            app.Navigator.GoToHomePage();
        }
    }
}

