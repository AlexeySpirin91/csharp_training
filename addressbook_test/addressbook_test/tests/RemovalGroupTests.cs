using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test.tests
{
    [TestFixture]
    public class RemovalGroupTests:TestBase
	{
		public RemovalGroupTests()
		{
		}

        [Test]
        public void GroupRemovalTest()
        {
            string chapter = "groups";
            int num = 5;

            app.Navigator.GoToChapter(chapter);
            app.Groups.RemovalGroup(num);
            app.Navigator.GoToChapter("home");
        }
    }
}

