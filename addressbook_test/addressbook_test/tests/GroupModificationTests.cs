﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        public GroupModificationTests()
        {
        }

        [Test]
        public void GroupModificationTest()
        {
            Form newData = new Form("new_test_ololo", null, "new_footer");
            Form form = new Form("test_modif", "header_modif", "footer_modif");
            int index = 0;

            app.Navigator.GoToGroupsPage();

            if (!app.Groups.CheckGroupOnPage())
            {
                app.Groups.Create(form.Name, form.Header, form.Footer);
                app.Navigator.GoToGroupsPage();
            }

            List<Form> oldGroups = Form.GetAll();
            Form toBeModify = oldGroups[index];
            app.Groups.Modify(toBeModify, newData.Name, newData.Header, newData.Footer);
            List<Form> newGroups = Form.GetAll();

            oldGroups[index].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            app.Navigator.GoToHomePage();

        }
    }


}