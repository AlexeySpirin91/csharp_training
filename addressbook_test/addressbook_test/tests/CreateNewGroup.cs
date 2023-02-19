﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_test
{
    [TestFixture]
    public class GroupCreateTest : AuthTestBase
    {
        [Test]
        public void GroupCreateTests()
        {
            Form form = new Form("test", "header", "footer");

            app.Navigator.GoToGroupsPage();
            app.Groups.Create(form.Name, form.Header, form.Footer);
        }

    }

}