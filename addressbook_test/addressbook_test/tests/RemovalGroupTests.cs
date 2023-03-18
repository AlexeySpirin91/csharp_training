using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    [TestFixture]
    public class RemovalGroupTests : GroupTestBase
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

            List<Form> oldGroups = Form.GetAll();
            Form toBeRemoved = oldGroups[index];

            app.Groups.Remove(toBeRemoved);

            List<Form> newGroups = Form.GetAll();

            oldGroups.RemoveAt(index);
            Assert.AreEqual(oldGroups, newGroups);

            foreach(Form form in newGroups)
            {
                Assert.AreNotEqual(form.Id, toBeRemoved.Id);
            }

            app.Navigator.GoToHomePage();
        }
    }
}

