using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    [TestFixture]
    public class GroupCreateTest : TestBase
    {
        [Test]
        public void GroupCreateTests()
        {

            string chapter = "groups";

            app.Navigator.GoToChapter(chapter);
            app.Groups.Create();
            app.Navigator.GoToChapter("home");
        }

    }
}
