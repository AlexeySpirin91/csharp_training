﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test.tests
{
    [TestFixture]
    public class GroupModificationTests:TestBase
	{
		public GroupModificationTests()
		{
		}

        [Test]
        public void GroupModificationTest()
        {
            Form newData = new Form("new_test", "new_header", "new_footer");
            string chapter = "groups";
            int index = 2;

            app.Navigator.GoToChapter(chapter);
            app.Groups.Modify(index, newData.Name, newData.Header, newData.Footer);
            app.Navigator.GoToChapter(chapter);
        }
    }
}

