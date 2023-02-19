using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
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
            int index = 5;

            app.Navigator.GoToChapter(chapter);
            app.Groups.RemovalGroup(index);
            
        }
    }
}

