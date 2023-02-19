using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    [TestFixture]
    public class RemovalGroupTests:AuthTestBase
	{
		public RemovalGroupTests()
		{
		}

        [Test]
        public void GroupRemovalTest()
        {
            int index = 5;

            app.Navigator.GoToGroupsPage();
            app.Groups.RemovalGroup(index);
            app.Navigator.GoToHomePage();

        }
    }
}

