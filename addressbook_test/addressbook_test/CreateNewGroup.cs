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
            navigation.OpenPage(baseURL);
            loginHelper.LoginUser(user.Login, user.Pass);
            navigation.GoToChapter(chapter);
            group.FillNewElement();
            group.FillForm(form.Name,form.Header,form.Footer);
            group.SubmitGroupCreation();
            navigation.GoToChapter("home");
        }
    }
}
