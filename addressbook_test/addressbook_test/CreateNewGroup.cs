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
            OpenPage(baseURL);
            LoginUser(user.Login, user.Pass);
            GoToChapter(chapter);
            FillNewElement();
            FillForm(form.Name,form.Header,form.Footer);
            SubmitGroupCreation();
            ReturnTGrouopPage();
        }
    }
}
