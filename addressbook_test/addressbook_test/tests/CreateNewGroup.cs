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
            Form form = new Form("test", "header", "footer");
            string chapter = "groups";

            app.Navigator.GoToChapter(chapter);
            app.Groups.Create(form.Name,form.Header,form.Footer);
            app.Navigator.GoToChapter("home");
        }

    }
}
