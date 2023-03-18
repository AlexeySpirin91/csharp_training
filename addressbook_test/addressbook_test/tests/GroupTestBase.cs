using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
	public class GroupTestBase:AuthTestBase
	{
		public GroupTestBase()
		{
		}
		[TearDown]
		public void CompareGroupsUI_DB()
		{
			if (PERFOM_LONG_UI_CHECKS)
			{
                List<string> fromUI = app.Groups.GetGroupNameList();
                List<string> fromDB = Form.GetAllNames();

                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }

		}
	}
}

