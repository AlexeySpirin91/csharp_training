﻿using System;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_test
{
    [TestFixture]
    public class RemovalContactTests:TestBase
	{
		public RemovalContactTests()
		{
		}

        [Test]
        public void RemovalContactTest()
        {
            int index = 5;
            app.Navigator.GoToChapter("home");
            app.Contacts
                .ChooseElement(index)
                .DeleteContact();

        }
    }
}

