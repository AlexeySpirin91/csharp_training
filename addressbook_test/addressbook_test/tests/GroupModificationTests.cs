using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        public GroupModificationTests()
        {
        }

        [Test]
        public void GroupModificationTest()
        {
            Form newData = new Form("new_test", null, "new_footer");
            string chapter = "groups";
            int index = 3;


            app.Navigator.GoToChapter(chapter);
            app.Groups.Modify(index, newData.Name, newData.Header, newData.Footer);
            app.Navigator.GoToChapter("home");
        }
    }


}