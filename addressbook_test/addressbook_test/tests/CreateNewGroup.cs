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
            User user = new User("admin", "secret");
            Form form = new Form("test", "header", "footer");
            string chapter = "groups";
            app.Navigator.OpenPage(app.BaseUrl);
            app.Auth.LoginUser(user.Login, user.Pass);
            app.Navigator.GoToChapter(chapter);
            app.Groups.FillNewElement();
            app.Groups.FillForm(form.Name,form.Header,form.Footer);
            app.Groups.SubmitGroupCreation();
            app.Navigator.GoToChapter("home");
        }
    }
}
