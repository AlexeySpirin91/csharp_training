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
        public static IEnumerable<Form> RandomGroupDataProvider()
        {
            List<Form> groups = new List<Form>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new Form(GenerateRandomString(50), GenerateRandomString(60), GenerateRandomString(30)));
            }
            return groups;
;        }



        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreateTests(Form form)
        {

            app.Navigator.GoToGroupsPage();
            List<Form> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(form.Name, form.Header, form.Footer);
            List<Form> newGroups = app.Groups.GetGroupList();


            oldGroups.Add(form);
            oldGroups.Sort();
            newGroups.Sort();


            Assert.AreEqual(oldGroups, newGroups);
            app.Navigator.GoToHomePage();
        }

    }

}